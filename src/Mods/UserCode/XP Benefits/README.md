# XP Benefits
Reward players for maintaining a high xp rate with extra carry capacity and a bigger stomach!

Unless your server has changed the default settings, it works as follows:

### Players:
You can earn +6000 extra calorie capacity, +30kg higher weight limit for carrying items on your person and carry +50% blocks in the hands.
The higher your food xp and housing xp, the more benefit you get. Now you've a reason to still buy expensive once you've levelled your skills - Keep the economy going!
You'll need both food *and* housing xp; neglecting either xp type will really hurt the amount of reward you get.

Your skill rates are scaled by the "maximum" xp scores, minus the food base gain, to work out how much benefit you get.

...Skip over the examples if you're not interested in how the exact figure is calculated...
##### Example 1:
If you have 5% of the food xp and 80% of the housing xp, you'll get sqrt(0.05 * 0.8) = 20% of the benefits -> +1200 extra calorie space, +6kg weight limit and +10% hands stack limit.
Eating better food will pay dividends compared with improving your housing score when it's already way ahead of your food.

##### Example 2:
If you have 100% of the maximum food xp and 0 housing xp, you'll get no benefits. Build a house! Those furniture makers deserve sales too!

The maximum food is set at 120 (times server skill rate) and the maximum housing is set at 200 (times server skill rate). They are only 'maximum' in the sense that if you achieve it you'll get all of the listed benefit amount. If you can get higher, you'll keep earning more reward.

### Server Owners:
You can configure how the mod is set up through the Settings.cs file.
There you can set how much of each benefit to give and change how the food and housing xp are combined to give the benefit amount.
Instead of the geometric mean (default), if you wanted to you could set scale the rewards by the sum of the food and housing, or either the food or housing alone. 
You can also change what values are used as the maximum food and housing, and whether player's xp should be capped to those numbers.
See the example in the Settings.cs file.
All code is provided so if you have other ideas to adapt the mod to your needs you can totally do that.

## Installation:
Drop in the Mods folder in the server directory.

### Settings you need to change:
If:
	Your server started pre-9.6 (food xp works differently even after migrating to later versions)
Then:
	There is a setting you need to change at Settings.cs->XPConfig->ModsOverrideConfig

If:
	You use the All Big Shovel mod (this mod replaces the file from All Big Shovel. If you use the other version with files for each shovel type you can skip this step)
Then:
	There is a setting you need to change at Settings.cs->ExtraCarryStackLimitBenefit->ModsPreInitialize

If:
	You don't want the carry stack size benefit to increase the shovel amount
Then:
	There is a setting you need to change at Settings.cs->ExtraCarryStackLimitBenefit->ModsPreInitialize

## Uninstallation
Remove the "XP Benefits" folder from Mods/UserCode and delete Mods/UserCode/Tools/ShovelItem.override.cs

Do get in touch if you have any problems or queries.
Enjoy!

https://mod.io/g/eco/m/xp-benefits