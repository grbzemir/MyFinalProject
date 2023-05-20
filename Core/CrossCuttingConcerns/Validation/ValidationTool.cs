﻿using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool

    {
        public static void Validate(IValidator validator )

        {

            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}