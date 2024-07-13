﻿//XP Benefits
//Copyright (C) 2023 Alex Docking
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Eco.Core.Plugins.Interfaces;
using Eco.Gameplay.EcopediaRoot;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;

namespace XPBenefits
{
    public class RegisterFoodBenefitFunction : IModInit
    {
        public static void Initialize()
        {
            XPBenefitsPlugin.RegisterBenefitFunctionFactory(new FoodBenefitFunctionFactory());
        }
    }

    /// <summary>
    /// Create a function that scales the benefit by the amount of food xp the player has
    /// </summary>
    public class FoodBenefitFunctionFactory : IBenefitFunctionFactory
    {
        public string Name { get; } = "FoodOnly";
        public string Description { get; } = "Uses only the amount of food xp the player has.";

        public IBenefitFunction Create(XPConfig xpConfig, BenefitValue maximumBenefit, bool xpLimitEnabled = false)
        {
            FoodXPInput input = new FoodXPInput(xpConfig);
            SimpleBenefitFunction benefitFunction = new SimpleBenefitFunction(new ClampInput(input, xpLimitEnabled), maximumBenefit);
            LocString inputTitle = Localizer.Do($"{Ecopedia.Obj.GetPage("Nutrition").UILink()} multiplier");
            benefitFunction.Describer = new InputDescriber(input)
            {
                InputName = "food XP",
                InputTitle = inputTitle,
                MeansOfImprovingStatDescription = Localizer.Do($"You can increase this benefit by improving your {inputTitle}"),
                AdditionalInfo = Localizer.DoStr("Note that 'Base Gain' is ignored when calculating your nutrition percentage"),
            };
            return benefitFunction;
        }
    }
}