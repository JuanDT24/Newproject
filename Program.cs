using System.Globalization;
using System;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;

namespace Newproject
{
    internal class Lab
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> price = new Dictionary<string, int>();
            price.Add("Crispeta Grande", 20000);
            price.Add("Crispeta Mediana", 15000);
            price.Add("Crispeta Pequeña", 10000);
            price.Add("Gaseosa Grande", 8000);
            price.Add("Gaseosa Pequeña", 6000);
            price.Add("Dulce", 5000);
            Productoa Crisp_Grande = new Productoa(1, "Crispeta", "mediana", 5, price);
            Console.WriteLine(Crisp_Grande.Preciounidad);


        }
    }
}



class Productoa
{
    private int productid;
    public int Productid
    {
        get { return productid; }
        set { productid = value; }
    }
    private string tipoproducto;
    public string Tipoproducto
    {
        get { return tipoproducto; }
        set { tipoproducto = value; }
    }
    private string tamaño;
    public string Tamaño { get { return tamaño; } set { tamaño = value; } }
    private int cantidad;
    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }
    private int preciounidad { get; set; }
    public int Preciounidad { get { return preciounidad; } set { preciounidad = value; } }


    public Productoa(int productid, string tipoproducto, string tamaño, int cantidad, Dictionary<string, int> price)
    {
        this.Productid = productid;
        this.Cantidad = cantidad;
        this.Tamaño = tamaño;
        this.Tipoproducto = tipoproducto;
        if (tipoproducto.Equals("Dulce", StringComparison.InvariantCultureIgnoreCase))
        {
            this.Preciounidad = 5000;
        }
        else
        {
            this.Preciounidad = Precio(price);
        }

    }
    public string Tiempo_De_Espera(Dictionary<string, string> Wait_time)
    {
        foreach (var item in Wait_time)
        {
            if (this.Tipoproducto == item.Key)
            {
                return "El tiempo de espera es " + item.Value;
            }
        }
        return "";

    }

    protected int Precio(Dictionary<string, int> Prices)
    {
        foreach (var item in Prices)
        {
            string[] Type = item.Key.Split(" ");
            if (Type[0].Equals(this.Tipoproducto, StringComparison.InvariantCultureIgnoreCase) & (Type[1].Equals(this.Tamaño, StringComparison.InvariantCultureIgnoreCase)))
            {
                return item.Value;
            }

        }
        return 0;

    }
}

class Tienda
{
    private List<Productoa>? lista_Productos;
    public List<Productoa> Lista_Productos
    {
        get { return lista_Productos; }
    }
    private float Factura;
    public void addProducto(Productoa producto)
    {
        lista_Productos.Add(producto);
    }
    public void deleteProducto(Productoa producto)
    {
        lista_Productos.Remove(producto);
    }
    public void Compra(Productoa producto, Usuario user, int cantidadcompra)
    {
        producto.Cantidad-=cantidadcompra;
    }
}
class Usuario
{
    public string nombre;
    public int telefono;
    public int factura = 0;
    public Usuario(string Nombre, int telefono)
    {
        this.nombre = Nombre;
        this.telefono = telefono;  
    }
}