using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PurchasePrice).NotEmpty();
            RuleFor(x => x.SellingPrice).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StockAmount).NotEmpty();
            RuleFor(x => x.ShippingId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.PurchasePrice).LessThan(x => x.SellingPrice).WithMessage("Ürünün Satış Fiyatı Alış Fiyatından Düşük Olamaz.");
            RuleFor(x => x.PurchasePrice).GreaterThan(0);
            RuleFor(x => x.SellingPrice).GreaterThan(0);

        }
    }
}
