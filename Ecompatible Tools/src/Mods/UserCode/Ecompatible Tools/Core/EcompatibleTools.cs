﻿namespace Ecompatible
{
    public static partial class ValueResolvers
    {
        public static ToolResolvers Tools { get; } = new ToolResolvers();
    }
    public partial class ToolResolvers
    {
        public ShovelResolvers Shovel { get; } = new ShovelResolvers();
        public PickaxeResolvers Pickaxe { get; } = new PickaxeResolvers();
        public AxeResolvers Axe { get; } = new AxeResolvers();
    }
    public partial class ShovelResolvers
    {
        /// <summary>
        /// List of modifiers that change MaxTake.
        /// </summary>
        public IPriorityValueResolver<float> MaxTakeResolver { get; } = ValueResolverFactory.CreatePriorityResolver<float>((float.MaxValue, new CarriedInventoryMaxTakeFallback()));
    }
    public partial class PickaxeResolvers
    {
        public IPriorityValueResolver<float> MaxStackSizeResolver { get; } = ValueResolverFactory.CreatePriorityResolver<float>((float.MinValue, new MaxStackSizePickupLimit()));
        public MiningSweepingHandsResolvers MiningSweepingHands { get; } = new MiningSweepingHandsResolvers();
    }
    public partial class MiningSweepingHandsResolvers
    {
        public IPriorityValueResolver<float> PickUpRangeResolver { get; } = ValueResolverFactory.CreatePriorityResolver<float>((float.MinValue, new DefaultPickupRange()));
    }
    public partial class AxeResolvers
    {
        public IPriorityValueResolver<float> MaxPickupLogsResolver { get; } = ValueResolverFactory.CreatePriorityResolver<float>((float.MinValue, new MaxStackSizeLogPickupLimit()));
    }
}