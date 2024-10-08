﻿using Eco.Gameplay.Players;
using Eco.Shared.Logging;
using Eco.Shared.Utils;
using System.Linq;

namespace XPBenefits
{
    public abstract class BenefitBase : IUserBenefit
    {
        /// <summary>
        /// Whether players can continue gaining benefits above those defined
        /// or whether their xp should be capped for the purposes of the calculation
        /// e.g. 55 food xp is the same as 50 if the config says the maximum food is 50.
        /// </summary>
        public virtual bool XPLimitEnabled { get; protected set; }

        protected virtual XPConfig XPConfig { get; set; }
        public virtual BenefitValue MaxBenefitValue { get; protected set; }
        public virtual IBenefitFunction BenefitFunction { get; protected set; }
        public virtual bool Enabled { get; protected set; } = true;

        public abstract void ApplyBenefitToUser(User user);

        public abstract void RemoveBenefitFromUser(User user);

        protected virtual IBenefitFunction CreateBenefitFunction(string benefitFunctionType, XPConfig xpConfig, BenefitValue maxBenefitValue, bool xpLimitEnabled)
        {
            IBenefitFunctionFactory factory = XPBenefitsPlugin.Obj.CreatableBenefitFunctions.FirstOrDefault(factory => factory.Name == benefitFunctionType);

            if (factory == null)
            {
                Log.WriteWarningLineLoc($"Warning: {GetType().Name} has an invalid benefit function \"{benefitFunctionType}\". Set a valid option and restart the server. Until then this benefit will be disabled.");
                return null;
            }
            return factory.Create(xpConfig, maxBenefitValue, xpLimitEnabled);
        }

        public abstract void Initialize();

        public void Initialize(bool enabled, XPConfig xpConfig, BenefitValue maxBenefitValue, bool xpLimitEnabled, IBenefitFunction benefitFunction)
        {
            Enabled = enabled;
            XPConfig = xpConfig;
            MaxBenefitValue = maxBenefitValue;
            XPLimitEnabled = xpLimitEnabled;
            BenefitFunction = benefitFunction;
        }

        public void Initialize(bool enabled, XPConfig xpConfig, BenefitValue maxBenefitValue, bool xpLimitEnabled, string benefitFunctionType)
        {
            Enabled = enabled;
            MaxBenefitValue = maxBenefitValue;
            XPLimitEnabled = xpLimitEnabled;
            BenefitFunction = CreateBenefitFunction(benefitFunctionType, xpConfig, maxBenefitValue, xpLimitEnabled);

            if (BenefitFunction == null)
            {
                Enabled = false;
            }
        }
    }
}