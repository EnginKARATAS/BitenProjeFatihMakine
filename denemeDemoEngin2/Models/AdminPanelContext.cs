using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projeAdiniz.Models
{
    public class AdminPanelContext : DbContext
    {
        public DbSet<Sayfa> Sayfa { get; set; }
        public DbSet<MetinDuzenle> MetinDuzenle { get; set; }
        public DbSet<ResimDuzenle> ResimDuzenle { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<urunKategori> urunKategori { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<urunResim> urunResim { get; set; }
        public DbSet<haberler> haberler { get; set; }
        public DbSet<slider> slider { get; set; }
        public DbSet<sliderIcerik> sliderIcerik { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<iletisimFormu> iletisimFormu { get; set; }
        public DbSet<firma> firma { get; set; }
        public DbSet<muhtarlar> muhtarlar { get; set; }
        public DbSet<etiketler> etiketler { get; set; }
        public DbSet<APSayfaKategorileri> APSayfaKategorileri { get; set; }
        public DbSet<firmaMusteri> firmaMusteri { get; set; }
        public DbSet<meclisUyeleri> meclisUyeleri { get; set; }
        public DbSet<eskiBaskanlar> eskiBaskanlar { get; set; }
        public DbSet<galeri> galeri { get; set; }
        public DbSet<firmapersoneller> firmapersoneller { get; set; }
        public DbSet<encumenler> encumenler { get; set; }
        public DbSet<baskanYardimcilari> baskanYardimcilari { get; set; }
        public DbSet<birimler> birimler { get; set; }
        public DbSet<Kararlar> Kararlar { get; set; }
        public DbSet<Etkinlikler> Etkinlikler { get; set; }
        public DbSet<faaliyetRaporlari> faaliyetRaporlari { get; set; }
        public DbSet<yerler> yerler { get; set; }
        public DbSet<sehitlerimiz> sehitlerimiz { get; set; }
        public DbSet<videoGaleri> videoGaleri { get; set; }
        public DbSet<projeler> projeler { get; set; }
        public DbSet<vefatEdenler> vefatEdenler { get; set; }
        public DbSet<belgeler> belgeler { get; set; }
        public DbSet<resimler> resimler { get; set; }
        public DbSet<demolar> demolar { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sayfa>().ToTable("Sayfa");
            modelBuilder.Entity<MetinDuzenle>().ToTable("MetinDuzenle");
            modelBuilder.Entity<ResimDuzenle>().ToTable("ResimDuzenle");
            modelBuilder.Entity<Urun>().ToTable("Urun");
            modelBuilder.Entity<urunKategori>().ToTable("urunKategori");
            modelBuilder.Entity<Kullanici>().ToTable("Kullanici");
            modelBuilder.Entity<urunResim>().ToTable("urunResim");
            modelBuilder.Entity<haberler>().ToTable("haberler");
            modelBuilder.Entity<slider>().ToTable("slider");
            modelBuilder.Entity<sliderIcerik>().ToTable("sliderIcerik");
            modelBuilder.Entity<Duyurular>().ToTable("Duyurular");
            modelBuilder.Entity<iletisimFormu>().ToTable("iletisimFormu");
            modelBuilder.Entity<firma>().ToTable("firma");
            modelBuilder.Entity<muhtarlar>().ToTable("muhtarlar");
            modelBuilder.Entity<etiketler>().ToTable("etiketler");
            modelBuilder.Entity<APSayfaKategorileri>().ToTable("APSayfaKategorileri");
            modelBuilder.Entity<firmaMusteri>().ToTable("firmaMusteri");
            modelBuilder.Entity<meclisUyeleri>().ToTable("meclisUyeleri");
            modelBuilder.Entity<eskiBaskanlar>().ToTable("eskiBaskanlar");
            modelBuilder.Entity<galeri>().ToTable("galeri");
            modelBuilder.Entity<firmapersoneller>().ToTable("firmapersoneller");
            modelBuilder.Entity<encumenler>().ToTable("encumenler");
            modelBuilder.Entity<baskanYardimcilari>().ToTable("baskanYardimcilari");
            modelBuilder.Entity<birimler>().ToTable("birimler");
            modelBuilder.Entity<Kararlar>().ToTable("Kararlar");
            modelBuilder.Entity<Etkinlikler>().ToTable("Etkinlikler");
            modelBuilder.Entity<faaliyetRaporlari>().ToTable("faaliyetRaporlari");
            modelBuilder.Entity<yerler>().ToTable("yerler");
            modelBuilder.Entity<sehitlerimiz>().ToTable("sehitlerimiz");
            modelBuilder.Entity<videoGaleri>().ToTable("videoGaleri");
            modelBuilder.Entity<projeler>().ToTable("projeler");
            modelBuilder.Entity<vefatEdenler>().ToTable("vefatEdenler");
            modelBuilder.Entity<belgeler>().ToTable("belgeler");
            modelBuilder.Entity<resimler>().ToTable("resimler");
            modelBuilder.Entity<demolar>().ToTable("demolar");

        }
    }

    public class APSayfaKategorileri
    {
        [Key]
        public int sayfaKategoriId { get; set; }
        public string sayfaKodu { get; set; }
        public string sayfaTuru { get; set; }
    }
    public class baskanYardimcilari
    {
        [Key]
        public int baskanYardimcisiId { get; set; }

        public string baskanYardimcisiAdi { get; set; }

        public string baskanYardimcisifotograf { get; set; }

        public virtual firma firma { get; set; }


    }
    public class birimler
    {
        [Key]
        public int birimId { get; set; }
        public string birimAdi { get; set; }
        public string birimYetkiliAdi { get; set; }
        public string birimYetkiliFotograf { get; set; }
        public string birimYetkiliGorevTr { get; set; }
        public string birimYetkiliGorevEn { get; set; }
        public string birimYetkiliTelefon { get; set; }
        public string birimYetkiliEmail { get; set; }
        public virtual firma firma { get; set; }


    }

    public class demolar
    {
        [Key]
        public int demoId { get; set; }
        public string demoAdi { get; set; }
        public string demoUrl { get; set; }

    }

    public class Duyurular
    {
        [Key]
        public int id { get; set; }

        public string duyuruTR { get; set; }

        public string duyuruEN { get; set; }

        public DateTime tarih { get; set; }
        public virtual firma firma { get; set; }


    }
    public class encumenler
    {
        [Key]
        public int encumenId { get; set; }

        public string encumenAdi { get; set; }

        public string encumenfotograf { get; set; }

        public virtual firma firma { get; set; }


    }
    public class eskiBaskanlar
    {
        [Key]
        public int eskiBaskanId { get; set; }

        public string eskiBaskanAdi { get; set; }

        public string baskanlikDonemi { get; set; }

        public string fotograf { get; set; }

        public virtual firma firma { get; set; }


    }
    public class etiketler
    {
        [Key]
        public int etiketId { get; set; }
        public string etiketAdi { get; set; }
        public virtual Urun urun { get; set; }
    }
    public class Etkinlikler
    {
        [Key]
        public int etkinlikId { get; set; }

        public string baslikTr { get; set; }
        public string baslikEn { get; set; }
        public string metinTr { get; set; }
        public string metinEn { get; set; }
        public string adres { get; set; }
        public DateTime tarih { get; set; }
        public string saat { get; set; }
        public string kapakFotografi { get; set; }
        public virtual firma firma { get; set; }

    }
    public class faaliyetRaporlari
    {
        [Key]
        public int raporId { get; set; }
        public string baslikTr { get; set; }
        public string baslikEn { get; set; }
        public string dosya { get; set; }
        public string donem { get; set; }
        public virtual firma firma { get; set; }

    }
    public class firma
    {
        [Key]
        public int firmaId { get; set; }
        public string firmaAdiTr { get; set; }
        public string firmaAdiEn { get; set; }
        public string firmaYetkili { get; set; }
        public string firmaTelefon { get; set; }
        public string firmaEmail { get; set; }
        public string firmaDomain { get; set; }
        public string firmaTuru { get; set; }
        public string firmaKonumu { get; set; }

    }
    public class firmaMusteri
    {
        [Key]
        public int firmaMusteriId { get; set; }

        public string adSoyad { get; set; }

        public string eMail { get; set; }

        public string telefon { get; set; }

        public string sifre { get; set; }
        public virtual firma firma { get; set; }


    }
    public class firmapersoneller
    {
        [Key]
        public int personelId { get; set; }
        public string personelAdi { get; set; }
        public string personelGoreviTr { get; set; }
        public string personelGoreviEn { get; set; }
        public string personelfotograf { get; set; }

        public virtual firma firma { get; set; }


    }
    public class galeri
    {
        [Key]
        public int resimId { get; set; }
        public string resimAciklamaTr { get; set; }
        public string resimAciklamaEn { get; set; }
        public string resimYolu { get; set; }
        public string galeriTuru { get; set; }

        public virtual firma firma { get; set; }
    }
    public class haberler
    {
        [Key]
        public int haberId { get; set; }

        public string baslikTr { get; set; }
        public string baslikEn { get; set; }
        public string metinTr { get; set; }
        public string metinEn { get; set; }
        public DateTime tarih { get; set; }
        public string kapakFotografi { get; set; }
        public virtual firma firma { get; set; }

    }
    public class iletisimFormu
    {
        [Key]
        public int iletisimFormId { get; set; }
        public string isim { get; set; }
        public string konu { get; set; }
        public string mesaj { get; set; }
        public string email { get; set; }
        public string tip { get; set; }
        public virtual firma firma { get; set; }

    }
    public class Kararlar
    {
        [Key]
        public int KararId { get; set; }
        public string konusuTr { get; set; }
        public string ozetTr { get; set; }
        public string konusuEn { get; set; }
        public string ozetEn { get; set; }
        public string dosya { get; set; }
        public string kararTipi { get; set; }
        public DateTime kararTarihi { get; set; }
        public virtual firma firma { get; set; }

    }
    public class Kullanici
    {
        [Key]
        public int kullaniciId { get; set; }

        public string adSoyad { get; set; }

        public string eMail { get; set; }

        public string telefon { get; set; }

        public string sifre { get; set; }
        public virtual firma firma { get; set; }
        public string rol { get; set; }


    }
    public class meclisUyeleri
    {
        [Key]
        public int uyeId { get; set; }
        public string uyeAdi { get; set; }
        public string goreviTr { get; set; }
        public string goreviEn { get; set; }
        public string meclisUyesiFotograf { get; set; }

        public virtual firma firma { get; set; }
    }
    public class MetinDuzenle
    {
        [Key]
        public int metinId { get; set; }

        public virtual Sayfa sayfa { get; set; }

        public string aciklama { get; set; }
        public string cssId { get; set; }

        public string veriTr { get; set; }

        public string veriEn { get; set; }

        public virtual firma firma { get; set; }


    }
    public class muhtarlar
    {
        [Key]
        public int muhtarId { get; set; }
        public string mahalleAdi { get; set; }
        public string muhtarAdi { get; set; }
        public string muhtarlikTelefonu { get; set; }
        public string muhtarlikAdresi { get; set; }
        public string muhtarFotograf { get; set; }
        public virtual firma firma { get; set; }
    }
    public class projeler
    {
        [Key]
        public int projeId { get; set; }
        public string projeAdiTr { get; set; }
        public string projeAdiEn { get; set; }
        public string projeAciklamaTr { get; set; }
        public string projeAciklamaEn { get; set; }
        public string projeDurumu { get; set; }
        public virtual firma firma { get; set; }
        public string kapakFotografi { get; set; }
    }
    public class ResimDuzenle
    {
        [Key]
        public int resimId { get; set; }

        public virtual Sayfa sayfa { get; set; }

        public string aciklama { get; set; }
        public string cssId { get; set; }

        public string resimYolu { get; set; }
        public virtual firma firma { get; set; }


    }
    public class Sayfa
    {
        [Key]
        public int sayfaId { get; set; }
        public string sayfaKodu { get; set; }

        public string adTr { get; set; }

        public string adEn { get; set; }

        public string sayfaTuru { get; set; }
    }
    public class sehitlerimiz
    {
        [Key]
        public int sehitId { get; set; }
        public string sehitAdi { get; set; }
        public string sehitGoreviTr { get; set; }
        public string taziyeMesajiTr { get; set; }
        public string sehitGoreviEn { get; set; }
        public string taziyeMesajiEn { get; set; }
        public string sehitFotografi { get; set; }
        public DateTime olumTarihi { get; set; }
        public virtual firma firma { get; set; }
    }
    public class slider
    {
        [Key]
        public int sliderId { get; set; }
        public string sliderAdi { get; set; }
    }
    public class sliderIcerik
    {
        [Key]
        public int slaytId { get; set; }

        public string baslikTr { get; set; }

        public string baslikEn { get; set; }

        public string metinTr { get; set; }

        public string metinEn { get; set; }

        public string resim { get; set; }
        public virtual firma firma { get; set; }
        public virtual slider slider { get; set; }
    }
    public class yerler
    {
        [Key]
        public int yerId { get; set; }
        public string yerAdiTr { get; set; }
        public string yerAdiEn { get; set; }
        public string yerAciklamaTr { get; set; }
        public string yerAciklamaEn { get; set; }
        public string yerTuru { get; set; }
        public virtual firma firma { get; set; }
        public string kapakFotografi { get; set; }

    }
    public class Urun
    {
        [Key]
        public int urunId { get; set; }

        public string adTr { get; set; }

        public string adEn { get; set; }

        public virtual urunKategori urunKategori { get; set; }

        public string aciklamaTr { get; set; }

        public string aciklamaEn { get; set; }

        public string fiyat { get; set; }

        public string kapakResim { get; set; }

        public string urunMetaBaslik { get; set; }

        public string urunMetaAciklama { get; set; }

    }
    public class urunResim
    {
        [Key]
        public int urunResimId { get; set; }

        public string resimYolu { get; set; }

        public int urunId { get; set; }
        public virtual firma firma { get; set; }


    }
    public class urunKategori
    {
        [Key]
        public int urunKategoriId { get; set; }

        public string adTr { get; set; }

        public string adEn { get; set; }

        public string aciklamaTr { get; set; }

        public string aciklamaEn { get; set; }

        public string kapakResmi { get; set; }
        public virtual firma firma { get; set; }

    }
    public class videoGaleri
    {
        [Key]
        public int videoId { get; set; }
        public string videoAciklamaTr { get; set; }
        public string videoAciklamaEn { get; set; }
        public string videoYolu { get; set; }
        public virtual firma firma { get; set; }
    }
    public class vefatEdenler
    {
        [Key]
        public int vefatEdenId { get; set; }
        public string vefatEdenAdı { get; set; }
        public DateTime olumTarihi { get; set; }
        public string yer { get; set; }
        public string vakit { get; set; }
        public string taziyeAdresi { get; set; }
        public string anaBabaAdi { get; set; }
        public string dogumYeri { get; set; }
        public string dogumYili { get; set; }
        public virtual firma firma { get; set; }
    }
    public class belgeler
    {
        [Key]
        public int belgeId { get; set; }
        public string belgeAdiTr { get; set; }
        public string belgeAdiEn { get; set; }
        public string belgeAdresi { get; set; }
        public virtual firma firma { get; set; }
    }
    public class resimler
    {
        [Key]
        public int resimId { get; set; }
        public string resimYolu { get; set; }
        public string resimTuru { get; set; }
        public int sahipId { get; set; }
        public virtual firma firma { get; set; }
    }
}