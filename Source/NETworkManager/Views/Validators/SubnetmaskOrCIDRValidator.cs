﻿using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using NETworkManager.Utilities.Common;

namespace NETworkManager.Views.Validators
{
    public class SubnetmaskOrCIDRValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value as string, RegexHelper.SubnetmaskRegex))
                return ValidationResult.ValidResult;

            int cidr;

            if (int.TryParse(value as string, out cidr))
            {
                if (cidr >= 0 && cidr < 33)
                    return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, Application.Current.Resources["String_ValidateError_EnterValidSubnetmaskOrCIDR"] as string);
        }
    }
}
