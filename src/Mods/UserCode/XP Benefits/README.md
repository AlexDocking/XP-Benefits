# XP Benefits
Reward players for maintaining a high xp rate with extra carry capacity and a bigger stomach!

*The rewards are an optional QoL bonus for participating in the economy. There's no penalty for eating cheap food if you still want to.*

Unless your server has changed the default settings, it works as follows:

### Players:
You can earn +6000 extra calorie capacity, +30kg higher weight limit for carrying items on your person and carry +100% blocks in the hands.
The higher your food xp and housing xp, the more benefit you get. Now you've a reason to still buy expensive once you've levelled your skills - Keep the economy going!
You'll need both food *and* housing xp; neglecting either xp type will really hurt the amount of reward you get.

Your skill rates are scaled by the "maximum" xp scores, minus the food base gain, to work out how much benefit you get.
The maximum food is set at 120 (times server skill rate) and the maximum housing is set at 200 (times server skill rate). They are only 'maximum' in the sense that if you achieve it you'll get all of the listed benefit amount. If you can get higher, you'll keep earning more reward.

...Skip over the examples if you're not interested in how the exact figure is calculated...
##### Example 1:
If you have 5% of the food xp and 80% of the housing xp, you'll get sqrt(0.05 * 0.8) = 20% of the benefits -> +1200 extra calorie space, +6kg weight limit and +50% hands stack limit.
Eating better food will pay dividends compared with improving your housing score when it's already way ahead of your food.

##### Example 2:
If you have 100% of the maximum food xp and 0 housing xp, you'll get no benefits. Build a house! Those furniture makers deserve sales too!


### Server Owners:
You can configure how the mod is set up through the Settings.cs file.
There you can set how much of each benefit to give and change how the food and housing xp are combined to give the benefit amount.
Instead of the geometric mean (default), if you wanted to you could scale the rewards by the sum of the food and housing, or either the food or housing alone. 
You can also change what values are used as the maximum food and housing, and whether player's xp should be capped to those numbers.
See the example in the Settings.cs file.
All code is provided so if you have other ideas to adapt the mod to your needs you can totally do that.

### Settings you need to change:
If:
	You use the (All) Big Shovel mod (this mod replaces the file ShovelItem.override from All Big Shovel)
Then:
	You need to go to ShovelItem.override and set MaxTake to 0

## Installation:
Unzip and drop it in the server directory.

## Uninstallation
Go to Mods/UserCode and delete the folder "XP Benefits", and the files Tools/ShovelItem.override.cs, Objects/TreeObject.override.cs and Benefits/SweepingHands.override.cs

Do get in touch if you have any problems or queries.
Enjoy!

https://mod.io/g/eco/m/xp-benefits

## Changelog
### v1.2.1
- Update for Eco v0.10.2.3
### v1.2.0
- Update for Eco v0.10.0. Remove option to exclude the bonus from shovels (IncreaseShovelSize) - now it is always applied
### v1.1.0
- Make sweeping hands pick up the extra rocks you should be allowed to hold
- Update uninstallation instructions
### v1.0.1
- Fix issue with stat modifiers potentially not being removed on log out (which would have appeared in the console log)
### v1.0.0
- Initial release