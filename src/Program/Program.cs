//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList();

        private static ArrayList equipmentCatalog = new ArrayList();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));
            recipe.PrintRecipe();
        }

        //Invariante, los productos del catalogo no varían sin cambiar el código.
        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        //Precondición: description no debe ser un string vacio, ni el hourlyCost menor a 0.
        //Postcondición: productCatalog tendrá un elemento más.
        private static void AddProductToCatalog(string description, double unitCost)
        {
            try
            {
                if(description == "")
                {
                    throw new NameEmpty("La descripción está vacía");
                }
                if(unitCost < 0)
                {
                    throw new LessThanZero("El costo es invalido por ser menor a 0");
                }
                productCatalog.Add(new Product(description, unitCost));
            }
            catch (NameEmpty e)
            {
                Console.WriteLine(e.Message);
            }  
            catch (LessThanZero f)
            {
                Console.WriteLine(f.Message);
            }
        }

        //Precondición: description no debe ser un string vacio, ni el hourlyCost menor a 0.
        //Postcondición: productCatalog tendrá un elemento más.
        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            try
            {
                if(description == "")
                {
                    throw new NameEmpty("La descripción está vacía");
                }
                if(hourlyCost < 0)
                {
                    throw new LessThanZero("El costo es invalido por ser menor a 0");
                }
                equipmentCatalog.Add(new Equipment(description, hourlyCost));
            }
            catch (NameEmpty e)
            {
                Console.WriteLine(e.Message);
            } 
            catch (LessThanZero f)
            {
                Console.WriteLine(f.Message);
            }
        }

        //Pre-condición: Debe haber un objeto Product en el indice dado.
        //Post-condición: Se devuelve el objeto Product que se encontraba en ese indice.
        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        //Pre-condición: Debe haber un objeto Equipment en el indice dado.
        //Post-condición: Se devuelve el objeto Equipment que se encontraba en ese indice.
        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        //Pre-condición: Debe haber un objeto Product con el description pasado por parametro.
        //Post-condición: Se devuelve el objeto Product con el description pasado por parametro        
        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        //Pre-condición: Debe haber un objeto Equipment con el description pasado por parametro.
        //Post-condición: Se devuelve el objeto Equipment con el description pasado por parametro   
        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}
