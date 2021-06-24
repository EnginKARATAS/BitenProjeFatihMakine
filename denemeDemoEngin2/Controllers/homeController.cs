using denemeDemoEngin2;
using projeAdiniz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace denemeDemoEngin2.Controllers
{
    public class homeController : Controller
    {
        AdminPanelContext APC = new AdminPanelContext();
        // GET: Home
        string dil = null;
        firma firma = null;
        int VeriGetir(string sayfaKodu)
        {
            TempData.Clear();
            string url = "fatihmakine.togdemyazilim.com";
            firma = APC.firma.FirstOrDefault(x => x.firmaDomain.ToLower() == url.ToLower());
            int firmaId = firma.firmaId;

            dil = (Session["dil"] != null ? Session["dil"].ToString() : null);

            Sayfa sayfa = APC.Sayfa.FirstOrDefault(x => x.sayfaKodu == sayfaKodu && (x.sayfaTuru == firma.firmaTuru || x.sayfaTuru == "ortak"));
            if (sayfa != null)
            {
                TempData["sayfaadi"] = (dil != null ? (dil == "tr" ? sayfa.adTr : sayfa.adEn) : sayfa.adTr);
                foreach (var veri in APC.MetinDuzenle.Where(x => ((x.sayfa.sayfaKodu == sayfaKodu || x.sayfa.sayfaKodu == "ortak") && x.firma.firmaId == firma.firmaId)))
                {
                    TempData[veri.cssId] = (dil != null ? (dil == "tr" ? veri.veriTr : veri.veriEn) : veri.veriTr);
                }
                foreach (var veri in APC.ResimDuzenle.Where(x => ((x.sayfa.sayfaKodu == sayfaKodu || x.sayfa.sayfaKodu == "ortak") && x.firma.firmaId == firma.firmaId)))
                {
                    TempData[veri.cssId] = veri.resimYolu;
                }

                foreach (var item in APC.urunKategori.Where(x => x.firma.firmaId == firmaId))
                {
                    TempData["urunkategorimenu"] += "<li><a href='" + Url.Action("urunler", "home", new { kategori = MetinKontrol.UrlDuzenle(this.Url, item.adTr), urunKategoriId = item.urunKategoriId }) + "'>" + (dil == "tr" || dil == null ? item.adTr : item.adEn) + "</a></li>";
                }
                TempData["firmaadi"] = firma.firmaAdiTr;

                TempData["metaetikletler"] = "" +
                    "<meta name='description' content='" + firma.firmaAdiTr + "'/>" +
                    "<meta name='title' content='" + firma.firmaAdiTr + "' />" +
                    "<meta name='keywords' content='" + firma.firmaAdiTr + "' />" +
                    "<meta name='owner' content='" + firma.firmaAdiTr + "' />" +
                        "<meta name='outher' content='TOGDEM Yazılım' /> ";
                return firma.firmaId;
            }
            else
            {
                return 0;
            }
        }

        public ActionResult Index()
        {
            VeriGetir("index");
            int sayac = 0;
            foreach (var item in APC.sliderIcerik.Where(x => x.firma.firmaId == firma.firmaId))
            {

                TempData["slider"] +=
         "<div class='carousel-item slide-2 " + (sayac == 0 ? "active" : "") + "' style='background-image: url(" + item.resim + ");background-position: top center;'>" +
          "  <div class='carousel-caption'>" +
               " <div class='container'>" +
                 "   <div class='box valign-middle'>" +
                      "  <div class='content text-center'>" +
                       "     <div class='bubbled-text-block animated fadeInLeft' data-animation='animated fadeInLeft'>" +
                         "       <div class='inner-box'>" +
                          "          <i class='facdori-icon-factory-3'></i>" +
                          "          <h3>" + TempData["founded"] + "</h3>" +
                          "      </div><!-- /.inner-box -->" +
                          "  </div><!-- /.bubbled-text-block -->" +
                          "  <h3 data-animation='animated fadeInDown' class='animated fadeInDown'>" + (Session["dil"] == null ? item.baslikTr : Session["dil"].ToString() == "tr" ? item.baslikTr : item.baslikEn) + "</h3>" +
                          "  <p data-animation='animated fadeInUp' class='animated fadeInUp'>" + (Session["dil"] == null ? item.metinTr : Session["dil"].ToString() == "tr" ? item.metinTr : item.metinEn) + "</p>" +
                         "   <a href='/home/contact' data-animation='animated fadeInDown' class='thm-btn animated fadeInDown'>" + (Session["dil"] == null ? "İletişim" : Session["dil"].ToString() == "tr" ? "İletişim" : "Contact") + "</a>" +
                      "  </div>" +
                  "  </div>" +
              "  </div>" +
          "  </div>" +
       " </div>";
                TempData["sliderAlt"] +="<li data-target='#minimal-bootstrap-carousel' data-slide-to='" + sayac + "' " + (sayac == 0 ? "class='active'" : "") + "></li>";

                sayac++;
            }
            foreach (var item in APC.haberler.Where(x => x.firma.firmaId == firma.firmaId))
            {
                TempData["news"] +=
                    "<div class='owl-stage-outer'>" +
                    "<div class='owl-item '>" +
                "    <div class='item'>" +
                 "       <div class='single-blog-style-three text-center'>" +
                  "          <div class='image-block'>" +
                   "             <img  style='width:100%;height:300px;object-fit:contain;'            src='" + item.kapakFotografi + "' alt='" + (dil == "tr" || dil == null ? item.baslikTr : item.baslikEn) + "' />" +
                    "            <div class='overlay'>" +
                     "               <div class='box'>" + 
                        "                <div class='content'>" +
                      "                      <h5>Haber hakkında bilgi</h5> <!-- /.dotted -->" +
                       "                 </div><!-- /.content -->" +
                         "           </div><!-- /.box -->" +
                         "       </div><!-- /.overlay -->" +
                         "   </div><!-- /.image-block -->" +
                          "  <div class='text-block'style='background:#d0c9c9;margin:10;'>" +
                           "     <div class='meta-info'>" +
                            "        <a href='/home/news?id='''>06 ağu, 2019</a>" +
                             "       <!--" +

                         "           <span class='sep'>-</span>" +
                        "          <!--" +

                      "              <a href='/home/news?id='''></a>" +
                       "         </div><!-- /.meta-info -->" +
                        "        <h3>" +
                         "           <a href='/home/news?id='''>" + (dil == null || dil == "tr" ? item.metinTr : item.metinEn)+
                           "             planlar" +
                            "        </a>" +
                            "    </h3>" +
                           " </div><!-- /.text-block -->" +
                           " </div><!-- /.text-block -->" +
                           " </div><!-- /.text-block -->" +
                           " </div><!-- /.text-block -->" +
                  "  </div>" +

           " </div>";

            }

            return View();
        }
        public ActionResult about()
        {
            
            VeriGetir("hakkimizda");
            return View();
        }

        public ActionResult products()
        {
            VeriGetir("urunkategoriler");
            foreach (var item in APC.urunKategori.Where(x => x.firma.firmaId==firma.firmaId))
            {
                TempData["urunkategoriler"] +=
"                <div class='col-lg-3 col-md-6 col-sm-6 col-xs-12'>" +
 "                   <div style='border: 1px solid;'class='single-project-style-one'>" +
  "                      <div class='image-block'>" +
   "                         <img  style='width:100%;height:300px;object-fit:contain;'src='"+item.kapakResmi+"' alt='Awesome Image'/>" +
    "                        <div class='overlay'>" +
     "                           <div class='box'>" +
      "                              <div class='content'>" +
       "                                 <div class='inner-content' style='background: #00000082;padding: 20px;width: 251px; '>" +
        "                                    <h3><a href='/home/products2?urunKategoriId=" + item.urunKategoriId + "'>" + (dil == null || dil == "tr" ? item.aciklamaTr : item.aciklamaEn) + "</a></h3>" +
         "                                   <p style='    padding-right: 19px;font-size: 15px;line-height:21px; '>There are many new variations of available but majority is simple free text.</p>" +
          "                                  <a href='/home/products2?urunKategoriId="+item.urunKategoriId+"' class='thm-btn style-two white-hover'>Daha fazla</a>" +
           "                             </div><!-- /.inner-content -->" +
            "                        </div><!-- /.content -->" +
             "                   </div><!-- /.box -->" +
              "              </div><!-- /.overlay -->" +
               "         </div><!-- /.image-block -->" +
                "    </div><!-- /.single-project-style-one -->" +
                "</div>";
            }
            return View();
        }
        public ActionResult products2(int? urunKategoriId)
        {
            int? Id = urunKategoriId;

            VeriGetir("urunler");
            foreach (var item in APC.Urun.Where(x => x.urunKategori.firma.firmaId == firma.firmaId && x.urunKategori.urunKategoriId==Id))
            {
                TempData["urunler"] +=
"                <div class='col-lg-3 col-md-6 col-sm-6 col-xs-12'>" +
 "                   <div style='border: 1px solid;'class='single-project-style-one'>" +
  "                      <div class='image-block'>" +
   "                         <img  style='width:100%;height:300px;object-fit:contain; 'src='" + item.kapakResim + "' alt='" + (dil == null || dil == "tr" ? item.adTr : item.adEn) + "" +
    "                        <div class='overlay'>" +
     "                           <div class='box'>" +
      "                              <div class='content'>" +
       "                                 <div style='width: 350px;text-align:center;' class='inner-content' style='background: #00000082;padding: 20px;width: 251px; '>" +
        "                                    <h3><a style='padding-right: 15%;' href='/home/productDetails?urunId=" + item.urunId + "'>" + (dil == null || dil == "tr" ? item.adTr : item.adEn) + "</a></h3>" +
         "                                   <p style='padding-right:19px;font-size: 15px;line-height:21px; '>" + (dil == null || dil == "tr" ? item.aciklamaTr : item.aciklamaEn) + "</p>" +
          "                                  <a href='/home/productDetails?urunId=" + item.urunId + "'style='margin-right: 27px; ' class='thm-btn style-two white-hover'>Daha fazla</a>" +
           "                             </div><!-- /.inner-content -->" +
            "                        </div><!-- /.content -->" + 
             "                   </div><!-- /.box -->" +
              "              </div><!-- /.overlay -->" +
               "         </div><!-- /.image-block -->" +
                "</div>";
            }
            return View();
        }
        public ActionResult productdetails(int? urunId)
        {
            int? Id = urunId;
            VeriGetir("urundetay");

            if (urunId != null)
            {
              
                Urun urun = APC.Urun.FirstOrDefault(x => x.urunId == Id);

                TempData["urunResim"] =urun.kapakResim;
                TempData["detayAd"] = dil == "tr" || dil == null ? urun.adTr : urun.adEn;
                TempData["detayAciklama"] = dil == "tr" || dil == null ? urun.aciklamaTr : urun.aciklamaEn;


            }
            return View();
        }
        public ActionResult news(int? haberId)
        {
            int? Id = haberId;
            VeriGetir("haberler");
            foreach (var item in APC.haberler.Where(x => x.firma.firmaId == firma.firmaId))
            {
                TempData["haberler"] +=
 "               <div class='col-lg-4'>" +
  "              <div class='single-blog-style-one'>" +
   "                 <div class='image-block'>" +
    "                    <img class='img-fluid'  style'width:100 ;height:300px; object-fit:contain;' src='" + item.kapakFotografi + "' alt='" + (dil == "tr" || dil == null ? item.baslikTr : item.baslikEn) + "' />" +
     "                   <div class='overlay'>" +
      "                      <div class='box'>" +
       "                         <div class='content'>" +
        "                            <div class='dotted'></div><!-- /.dotted -->" +
         "                       </div><!-- /.content -->" +
          "                  </div><!-- /.box -->" +
           "             </div><!-- /.overlay -->" +
            "        </div><!-- /.image-block -->" +
             "       <div class='text-block'>" +
              "          <div class='upper-block'>" +
               "<div class='date'>"+item.tarih.ToString("dd MMM")+"</div><!-- /.date -->" +
                "    <a href='/home/newsDetails?haberId="+item.haberId+"'> <h2 class='entry-title'>" + (dil == null || dil == "tr" ? item.baslikTr : item.baslikEn) + "</h2></a>" +
                 "           <p>" + (dil == null || dil == "tr" ? item.metinTr.ToString() : item.metinEn.ToString().Substring(0,50)) + "</p>" +
                  "      </div><!-- /.upper-block -->" +
                   "     <div class='meta-info'>" +
                    "        <a href='#'>Fatih Makina Haber</a>" +
                     "       <a href='#'>  </a>" +
 "                       </div><!-- /.meta-info -->" +
  "                  </div><!-- /.text-block -->" +
   "             </div><!-- /.single-blog-style-one -->" +
    "        </div>";
            }

           
            return View();
        }
        public ActionResult newsDetails(int? haberId)
        {
            int? Id = haberId;
            VeriGetir("habergoruntule");
            
            if (haberId != null)
            {
                int? id = haberId;
                haberler haber = APC.haberler.FirstOrDefault(x => x.haberId ==Id);

                TempData["newsDetailsİmg1"] = haber.kapakFotografi;
                TempData["newsDetailsBaslik"] = dil == "tr" || dil == null ? haber.baslikTr : haber.baslikEn;
                TempData["newsDetailsParagraph"] = dil == "tr" || dil == null ? haber.metinTr : haber.metinEn;



            }
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult tarih()
        {
            VeriGetir("tarihce");
            return View();
        }
    }
}