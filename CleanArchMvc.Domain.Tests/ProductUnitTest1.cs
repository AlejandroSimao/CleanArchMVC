using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameter_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name","Product Description", 9.99m, 99,"product image");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvaidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description",9.99m,99,"product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }
        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr","Product Description",9.99m,99,"product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 charecters");
        }

        [Fact]
        public void CreateProduct_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Product(1, "Procut", "Product Description", 9.99m, 99, 
                "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image too long, maximum 250 charecters");
        }
        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoReferenceException()
        {
            Action action = () => new Product(1, "Product", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product", "Product Description",99.9m ,99 , " ");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPrice_DomainException()
        {
            Action action = () => new Product(1, "Product", "Product Description", - 9.99m, 99, "procut image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStock_DomainException(int value)
        {
            Action action = () => new Product(1, "Product", "Product Description", 9.99m, value, "product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }
    }
}
