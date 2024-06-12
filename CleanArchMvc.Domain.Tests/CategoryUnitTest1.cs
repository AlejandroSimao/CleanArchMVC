using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCataegory_WithValidParameter_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCataegory_NegativeIdValue_DomainExceptionInvaidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid ID value");
        } 
        [Fact]
        public void CreateCataegory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 charecters");
        } 
        [Fact]
        public void CreateCataegory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name is required");
        } 
        [Fact]
        public void CreateCataegory_WhithNullNmaeValue_DomainExceptionInvaidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }
        

    }
}
