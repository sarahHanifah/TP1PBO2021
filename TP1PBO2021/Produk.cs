using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1PBO2021.Properties
{
    class Produk
    {
    }
}
class Produk
{
    public string nama { set; get; }
    public string jenis { set; get; }
    public int harga { set; get; }
    public string spesifikasi { set; get; }
    public Produk()
    {

    }
    public Produk(string nama, string jenis, int harga, string spesifikasi)
    {
        this.nama = nama;
        this.jenis = jenis;
        this.harga = harga;
        this.spesifikasi = spesifikasi;
    }
}