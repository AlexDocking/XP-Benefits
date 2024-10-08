﻿using Eco.Core;
using Eco.Gameplay.EcopediaRoot;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPBenefits
{
    public class XPBenefitsEcopediaManager : AutoSingleton<XPBenefitsEcopediaManager>
    {
        public XPBenefitsEcopediaManager()
        {
            PluginManager.Controller.RunIfOrWhenInited(AmendEcopedia);
        }
        private IDictionary<IUserBenefit, IBenefitEcopediaGenerator> EcopediaGenerators { get; } = new ConcurrentDictionary<IUserBenefit, IBenefitEcopediaGenerator>();
        public IBenefitEcopediaGenerator GetEcopedia(IUserBenefit userBenefit) => EcopediaGenerators.TryGetValue(userBenefit, out var generator) ? generator : null;
        /// <summary>
        /// Register a benefit with a corresponding object to create the ecopedia page, and the page will be created when the server finishes startup so long as the benefit is enabled.
        /// </summary>
        /// <param name="benefit"></param>
        /// <param name="ecopediaGenerator"></param>
        public void RegisterEcopediaPageGenerator(IUserBenefit benefit, IBenefitEcopediaGenerator ecopediaGenerator)
        {
            EcopediaGenerators.Add(benefit, ecopediaGenerator);
        }
        private void AmendEcopedia()
        {
            foreach(IUserBenefit benefit in EcopediaGenerators.Keys)
            {
                if (!benefit.Enabled)
                {
                    EcopediaGenerators[benefit].RemovePage();
                }
                else
                {
                    EcopediaGenerators[benefit].GetOrCreatePage();
                }
            }
            var benefits = XPBenefitsPlugin.Obj.Benefits;
            StringBuilder ecopediaBenefitsListBuilder = new StringBuilder();
            ecopediaBenefitsListBuilder.AppendLine(Text.Style(Text.Styles.Header, "List of Benefits:"));
            
            var pages = EcopediaGenerators.Values.Select(generator => generator.GetPage());
            foreach (var benefit in XPBenefitsPlugin.Obj.EnabledBenefits)
            {
                string pageLink = EcopediaGenerators.TryGetValue(benefit, out var generator) ? generator.GetPage().UILink() : benefit.GetType().Name.AddSpacesBetweenCapitals();
                ecopediaBenefitsListBuilder.AppendLine(pageLink);
            }
            LocString ecopediaPageList = ecopediaBenefitsListBuilder.ToStringLoc();
            
            if (XPBenefitsPlugin.Obj.EnabledBenefits.Any())
            {
                var section = new Eco.Gameplay.EcopediaRoot.EcopediaSection();
                section.Text = ecopediaPageList;
                EcopediaXPBenefitsOverviewPage.Sections.Insert(1, section);
                EcopediaXPBenefitsOverviewPage.ParseTagsInText();
            }
            else
            {
                Ecopedia.Obj.Chapters["Mods"].Categories.Remove(EcopediaXPBenefitsCategory);
            }
        }

        private EcopediaCategory EcopediaXPBenefitsCategory => Ecopedia.Obj.Chapters["Mods"].Categories.FirstOrDefault(category => category.Name == "XP Benefits");
        private EcopediaPage EcopediaXPBenefitsOverviewPage => EcopediaXPBenefitsCategory.Pages["XP Benefits Overview"];
    }
}
