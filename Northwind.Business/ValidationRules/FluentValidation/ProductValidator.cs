using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        //fluent validation 19 dil desteği mevcut.
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Lütfen ürün ismi giriniz");//Boş olamaz
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Lütfen kategori seçiniz.");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Lütfen fiyat giriniz.");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("lütfen ürünün birimini giriniz.");
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("lütfen Stok miktarı giriniz");

            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır."); //Yazan değerden büyük olmalı.
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0).WithMessage("Stok eksi olamaz.");
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2).WithMessage("Condiments için lütfen 10 birimden büyük bir fiyat giriniz.");//CategoryId 2 ise Unit price 10dan büyük olmalı.

           

        }
    }
}
 