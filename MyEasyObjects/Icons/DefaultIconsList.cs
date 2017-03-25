using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEasy.Common;
using MyEasyObjects.Object;

namespace MyEasyObjects.Icons
{
	public sealed class DefaultIconsList 
	{
		#region Members

        List<NameImage> mDefaultIcons = new List<NameImage>();
        List<NameImage> mFruitsIcons = new List<NameImage>();
        List<NameImage> mVegetablesIcons = new List<NameImage>();
        List<NameImage> mHealthySnacksIcons = new List<NameImage>();
        List<NameImage> mBeveragesIcons = new List<NameImage>();
        List<NameImage> mCakesPiesIcons = new List<NameImage>();
        List<NameImage> mMeatsIcons = new List<NameImage>();
        List<NameImage> mBreadsIcons = new List<NameImage>();
        List<NameImage> mFishIcons = new List<NameImage>();
        List<NameImage> mAlcoholIcons = new List<NameImage>();
        List<NameImage> mMiscIcons = new List<NameImage>();
        List<NameImage> mSweetsIcons = new List<NameImage>();
        List<NameImage> mIceCreamIcons = new List<NameImage>();
        List<NameImage> mCookiesAndBiscuitsIcons = new List<NameImage>();
        List<NameImage> mCondimentsIcons = new List<NameImage>();
        List<NameImage> mItalianIcons = new List<NameImage>();

		static readonly DefaultIconsList instance = new DefaultIconsList(64);

		#endregion

		public static DefaultIconsList Instance { get {return instance;} }

		public List<NameImage> DefaultIcons {get {return mDefaultIcons;}}
        public List<NameImage> FruitsIcons {get {return mFruitsIcons;}}
        public List<NameImage> VegetablesIcons {get {return mVegetablesIcons;}}
        public List<NameImage> HealthySnacksIcons {get {return mHealthySnacksIcons;}}
        public List<NameImage> BeveragesIcons {get {return mBeveragesIcons;}}
        public List<NameImage> CakesPiesIcons {get {return mCakesPiesIcons;}}
        public List<NameImage> MeatsIcons {get {return mMeatsIcons;}}
        public List<NameImage> BreadsIcons {get {return mBreadsIcons;}}
        public List<NameImage> FishIcons {get {return mFishIcons;}}
        public List<NameImage> AlcoholIcons {get {return mAlcoholIcons;}}
        public List<NameImage> MiscIcons {get {return mMiscIcons;}}
        public List<NameImage> SweetsIcons {get {return mSweetsIcons;}}
        public List<NameImage> IceCreamIcons {get {return mIceCreamIcons;}}
        public List<NameImage> CookiesAndBiscuitsIcons {get {return mCookiesAndBiscuitsIcons;}}
        public List<NameImage> CondimentsIcons {get {return mCondimentsIcons;}}
        public List<NameImage> ItalianIcons { get { return mItalianIcons; } }

		public static string DefaultIconPath {get {return "/Images/Icons_64/";}}

		public static string MaleIcon {get {return DefaultIconPath + "Administrator-icon.png";}}

		public static string FemaleIcon {get {return DefaultIconPath + "Office-Girl-icon.png";}}

		public static string QuestionMarkIcon {get {return DefaultIconPath + "Help-icon.png";}}

		DefaultIconsList(int iconSize)
		{
			mDefaultIcons.Add(new NameImage("A Star", DefaultIconPath +"a_big_star_" + iconSize + ".png", 0));
			mDefaultIcons.Add(new NameImage("Almond", DefaultIconPath +"almond_" + iconSize + ".png", 1));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Apples", DefaultIconPath +"apples_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Apple juice", DefaultIconPath +"apple_juice_" + iconSize + ".png", 2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Apple pie", DefaultIconPath +"apple_pie_" + iconSize + ".png", 3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Bacon", DefaultIconPath +"bacon_" + iconSize + ".png", 2));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Corn bread", DefaultIconPath +"baked_corn_" + iconSize + ".png", 3));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Baked salmon", DefaultIconPath +"baked_salmon_" + iconSize + ".png", 4));
            mFishIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Banana", DefaultIconPath +"banana_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Beans", DefaultIconPath +"beans_" + iconSize + ".png", 1));
			mDefaultIcons.Add(new NameImage("Beef", DefaultIconPath +"beef_" + iconSize + ".png", 4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Beer", DefaultIconPath +"beer_" + iconSize + ".png", 3));
            mAlcoholIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Birthday cake", DefaultIconPath +"birthday_cake_" + iconSize + ".png", 4));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Black forest pastry", DefaultIconPath +"black_forest_pastry_" + iconSize + ".png", 4));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Blueberries", DefaultIconPath +"blueberries_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Boiled eggs", DefaultIconPath +"boiled_egg_" + iconSize + ".png", 2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Brazil nuts", DefaultIconPath +"brazil_nuts_" + iconSize + ".png", 1));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Bread", DefaultIconPath +"bread_" + iconSize + ".png", 2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Brioche", DefaultIconPath +"brioche_" + iconSize + ".png", 2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Brown bread", DefaultIconPath +"brown_bread_" + iconSize + ".png", 2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Buns", DefaultIconPath +"buns_" + iconSize + ".png", 2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Butter", DefaultIconPath +"butter_" + iconSize + ".png", 1));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Butter scotch ice cream", DefaultIconPath +"butter_scotch_ice_cream_" + iconSize + ".png", 3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cake", DefaultIconPath +"cake_" + iconSize + ".png", 3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Candy", DefaultIconPath +"candy_" + iconSize + ".png", 2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fruit Cocktail", DefaultIconPath +"canned_food_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cappuccino", DefaultIconPath +"cappuccino_" + iconSize + ".png", 3));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Caramel apple", DefaultIconPath +"caramel_apple_" + iconSize + ".png", 2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cashew nuts", DefaultIconPath +"cashew_nuts_" + iconSize + ".png", 2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cereal", DefaultIconPath +"cereal_" + iconSize + ".png", 2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cheese", DefaultIconPath +"cheese_" + iconSize + ".png", 2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cherries", DefaultIconPath +"cherries_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chest nuts", DefaultIconPath +"chest_nuts_" + iconSize + ".png", 2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chewing gum", DefaultIconPath +"chewing_gum_" + iconSize + ".png", 1));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate", DefaultIconPath +"chocolate_" + iconSize + ".png", 2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate bar", DefaultIconPath +"chocolate_bar_" + iconSize + ".png", 2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate biscuits", DefaultIconPath +"chocolate_biscuits_" + iconSize + ".png", 2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate cake", DefaultIconPath +"chocolate_cake_" + iconSize + ".png", 3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate cookies", DefaultIconPath +"chocolate_cookies_" + iconSize + ".png", 2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate cream biscuit", DefaultIconPath +"chocolate_cream_biscuit_" + iconSize + ".png", 2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate glaze cake", DefaultIconPath +"chocolate_glaze_" + iconSize + ".png", 3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate ice cream bar", DefaultIconPath +"chocolate_ice_cream_bar_" + iconSize + ".png", 3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate mousse", DefaultIconPath +"chocolate_mousse_" + iconSize + ".png", 3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Chocolate muffins", DefaultIconPath +"chocolate_muffins_" + iconSize + ".png", 3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Moon pie", DefaultIconPath +"chocolate_pie_" + iconSize + ".png", 4));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Choux pastry", DefaultIconPath +"choux_pastry_" + iconSize + ".png", 2));
			//mDefaultIcons.Add(new NameImage("Clarified butter", DefaultIconPath +"clarified_butter_" + iconSize + ".png", 1));
			mDefaultIcons.Add(new NameImage("Club sandwich", DefaultIconPath +"club_sandwich_" + iconSize + ".png", 4));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cocktail", DefaultIconPath +"cocktail_" + iconSize + ".png", 3));
            mAlcoholIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Coffee", DefaultIconPath +"coffee_" + iconSize + ".png", 2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Coffee pot", DefaultIconPath +"coffee_pot_" + iconSize + ".png", 1));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cookies", DefaultIconPath +"biscotti_" + iconSize + ".png", 2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cola drink", DefaultIconPath +"cola_drink_" + iconSize + ".png", 1));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ice cream", DefaultIconPath +"cone_ice_cream_" + iconSize + ".png", 2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Corn dog", DefaultIconPath +"corn_dog_" + iconSize + ".png", 2));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cornflakes", DefaultIconPath +"corn_flakes_" + iconSize + ".png", 2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cotton candy", DefaultIconPath +"cotton_candy_" + iconSize + ".png", 3));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Crackers", DefaultIconPath +"crackers_" + iconSize + ".png", 1));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cranberries", DefaultIconPath +"cranberries_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cranberry juice", DefaultIconPath +"cranberry_juice_" + iconSize + ".png", 2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Croissant", DefaultIconPath +"croissant_" + iconSize + ".png", 2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Cup ice cream", DefaultIconPath +"cup_ice_cream_" + iconSize + ".png", 2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Custard", DefaultIconPath +"custard_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Cutlet", DefaultIconPath +"cutlet_" + iconSize + ".png", 4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Danish cookies", DefaultIconPath +"danish_cookies_" + iconSize + ".png", 2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Dark rum", DefaultIconPath +"dark_rum_" + iconSize + ".png", 3));
            mAlcoholIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Eclair", DefaultIconPath +"eclair_" + iconSize + ".png", 2));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Eggs", DefaultIconPath +"egg_" + iconSize + ".png", 1));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Espresso", DefaultIconPath +"espresso_" + iconSize + ".png",2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fig tart", DefaultIconPath +"fig_tart_" + iconSize + ".png",3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Flour", DefaultIconPath +"flour_" + iconSize + ".png",1));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("French fries", DefaultIconPath +"french_fries_" + iconSize + ".png",3));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Wine", DefaultIconPath +"french_wine_" + iconSize + ".png",3));
            mAlcoholIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fried chicken", DefaultIconPath +"fried_chicken_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fried fish", DefaultIconPath +"fried_fish_" + iconSize + ".png",4));
            mFishIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Frozen banana", DefaultIconPath +"frozen_banana_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Fruitcake", DefaultIconPath +"fruitcake_" + iconSize + ".png",3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fruits", DefaultIconPath +"fruits_" + iconSize + ".png",3));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fudgesicle", DefaultIconPath +"fudgesicle_" + iconSize + ".png",2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ginger cookies", DefaultIconPath +"ginger_cookies_" + iconSize + ".png",2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Grapes", DefaultIconPath +"grapes_" + iconSize + ".png",2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Fresh Fruit Cake", DefaultIconPath +"grape_cake_" + iconSize + ".png",3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Green apple", DefaultIconPath +"green_apple_" + iconSize + ".png",2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Green tea", DefaultIconPath +"green_tea_" + iconSize + ".png",2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Grilled fish", DefaultIconPath +"grilled_fish_" + iconSize + ".png",4));
            mFishIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Hamburguer", DefaultIconPath +"hamburguer_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ham", DefaultIconPath +"ham_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Hazelnuts", DefaultIconPath +"hazelnuts_" + iconSize + ".png",2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Honey", DefaultIconPath +"honey_" + iconSize + ".png",2));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Hot chocolate", DefaultIconPath +"hot_chocolate_" + iconSize + ".png",3));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Hot dog", DefaultIconPath +"hot_dog_" + iconSize + ".png",3));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ice cream shake", DefaultIconPath +"ice_cream_shake_" + iconSize + ".png",3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ice cubes", DefaultIconPath +"ice_cubes_" + iconSize + ".png",1));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ice pop", DefaultIconPath +"ice_pop_" + iconSize + ".png",3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Irish coffee", DefaultIconPath +"irish_coffee_" + iconSize + ".png",3));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Kastera", DefaultIconPath +"kastera_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Kebab", DefaultIconPath +"kebab_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Ketchup", DefaultIconPath +"ketchup_" + iconSize + ".png",1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Lemon", DefaultIconPath +"lemon_" + iconSize + ".png",2));
            mVegetablesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Limeade", DefaultIconPath +"lime_cordial_" + iconSize + ".png",3));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Loaf", DefaultIconPath +"loaf_" + iconSize + ".png",2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Lollipop", DefaultIconPath +"lollipop_" + iconSize + ".png",2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Macadamia nuts", DefaultIconPath +"macadamia_nuts_" + iconSize + ".png",2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Macaroni and Cheese", DefaultIconPath +"macaroni_" + iconSize + ".png",3));
            mMiscIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Macaroons", DefaultIconPath +"macaroons_" + iconSize + ".png",3));
			mDefaultIcons.Add(new NameImage("Mayonnaise", DefaultIconPath +"mayonnaise_" + iconSize + ".png",1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Milk", DefaultIconPath +"milk_" + iconSize + ".png",2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Milk shake", DefaultIconPath +"milk_shake_" + iconSize + ".png",3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Muffin", DefaultIconPath +"muffin_" + iconSize + ".png",2));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Mushrooms", DefaultIconPath +"mushrooms_" + iconSize + ".png", 2));
            mVegetablesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Mustard", DefaultIconPath +"mustard_" + iconSize + ".png", 1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Mutton", DefaultIconPath +"mutton_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Noodles", DefaultIconPath +"noodles_" + iconSize + ".png",3));
			mDefaultIcons.Add(new NameImage("Nuts cake", DefaultIconPath +"nuts_cake_" + iconSize + ".png",4));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Oat meal", DefaultIconPath +"oat_meal_" + iconSize + ".png", 2));
			mDefaultIcons.Add(new NameImage("Omelette", DefaultIconPath +"omelette_" + iconSize + ".png", 3));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Orange", DefaultIconPath +"orange_" + iconSize + ".png", 2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Orange juice", DefaultIconPath +"orange_juice_" + iconSize + ".png",2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Parmesan cheese", DefaultIconPath +"parmesan_cheese_" + iconSize + ".png",2));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pasta", DefaultIconPath +"pasta_" + iconSize + ".png",3));
            mItalianIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Pastry", DefaultIconPath +"pastry_" + iconSize + ".png",3));
			mDefaultIcons.Add(new NameImage("Peanuts", DefaultIconPath +"peanuts_" + iconSize + ".png",2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Peanuts butter", DefaultIconPath +"peanuts_butter_" + iconSize + ".png",1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pear", DefaultIconPath +"pear_" + iconSize + ".png",2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pepper", DefaultIconPath +"pepper_" + iconSize + ".png",1));
            mVegetablesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pickle", DefaultIconPath +"pickle_" + iconSize + ".png",2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pineapple", DefaultIconPath +"ananas_" + iconSize + ".png",2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pine nuts", DefaultIconPath +"pine_nuts_" + iconSize + ".png",2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pistachios", DefaultIconPath +"pistachios_" + iconSize + ".png",2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pizza", DefaultIconPath +"pizza_" + iconSize + ".png",4));
            mItalianIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Pizza slice", DefaultIconPath +"pizza_slice_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Plum cake", DefaultIconPath +"plum_cake_" + iconSize + ".png",3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Popsicle", DefaultIconPath +"popsicle_" + iconSize + ".png",2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pop corn", DefaultIconPath +"pop_corn_" + iconSize + ".png",2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pork", DefaultIconPath +"pork_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Porridge", DefaultIconPath +"porridge_" + iconSize + ".png",2));
			mDefaultIcons.Add(new NameImage("Potato chips", DefaultIconPath +"potato_chips_" + iconSize + ".png",2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Pudding", DefaultIconPath +"pudding_" + iconSize + ".png",3));
            mMiscIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Raspberry syrup", DefaultIconPath +"raspberry_syrup_" + iconSize + ".png",1));
			mDefaultIcons.Add(new NameImage("Red apple", DefaultIconPath +"red_apple_" + iconSize + ".png",2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Rice cracker", DefaultIconPath +"rice_cracker_" + iconSize + ".png",2));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Roast chicken", DefaultIconPath +"roast_chicken_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Roast duck", DefaultIconPath +"roast_duck_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Roast turkey", DefaultIconPath +"roast_turkey_" + iconSize + ".png",4));
            mMeatsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Rocket pop", DefaultIconPath +"rocket_pop_" + iconSize + ".png"));
			//mDefaultIcons.Add(new NameImage("Rock candy", DefaultIconPath +"rock_candy_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Roll cake", DefaultIconPath +"roll_cake_" + iconSize + ".png",3));
            mCakesPiesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Salad", DefaultIconPath +"salad_" + iconSize + ".png",3));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Salt", DefaultIconPath +"salt_" + iconSize + ".png",1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sandwich", DefaultIconPath +"sandwich_" + iconSize + ".png",3));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sausage", DefaultIconPath +"sausage_" + iconSize + ".png",3));
            mMeatsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Scotch whisky", DefaultIconPath +"scotch_whisky_" + iconSize + ".png",3));
            mAlcoholIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sliced bread", DefaultIconPath +"sliced_bread_" + iconSize + ".png",2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Soda bar", DefaultIconPath +"soda_bar_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Soft Icecream", DefaultIconPath +"soft_cream_" + iconSize + ".png",3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Soft drinks", DefaultIconPath +"soft_drinks_" + iconSize + ".png",2));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Soup", DefaultIconPath +"soup_" + iconSize + ".png",4));
            mMiscIcons.Add(mDefaultIcons.Last());
            mDefaultIcons.Add(new NameImage("Spaghetti", DefaultIconPath + "spaghetti_" + iconSize + ".png", 3));
            mItalianIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Squash", DefaultIconPath +"squash_" + iconSize + ".png"));
			mDefaultIcons.Add(new NameImage("Steamed lobster", DefaultIconPath +"steamed_lobster_" + iconSize + ".png",4));
            mFishIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Strawberry", DefaultIconPath +"strawberry_" + iconSize + ".png",2));
            mFruitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Strawberry cream biscuit", DefaultIconPath +"strawberry_cream_biscuit_" + iconSize + ".png",2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Strawberry ice cream", DefaultIconPath +"strawberry_ice_cream_" + iconSize + ".png",2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sugar", DefaultIconPath +"sugar_" + iconSize + ".png",1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sugar cubes", DefaultIconPath +"sugar_cubes_" + iconSize + ".png",1));
            mCondimentsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sundae", DefaultIconPath +"sundae_" + iconSize + ".png",3));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Sweets", DefaultIconPath +"sweets_" + iconSize + ".png",2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Tea bags", DefaultIconPath +"tea_bag_" + iconSize + ".png",1));
            mBeveragesIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Toast", DefaultIconPath +"toast_" + iconSize + ".png",2));
            mBreadsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Toast marmalade", DefaultIconPath +"toast_marmalade_" + iconSize + ".png",2));
			mDefaultIcons.Add(new NameImage("Toffees", DefaultIconPath +"toffees_" + iconSize + ".png",2));
            mSweetsIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Tomato puree", DefaultIconPath +"tomato_puree_" + iconSize + ".png",1));
			mDefaultIcons.Add(new NameImage("Tomato soup", DefaultIconPath +"tomato_soup_" + iconSize + ".png",3));
            mItalianIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Tutti frutti ice cream", DefaultIconPath +"tutti_frutti_ice_cream_" + iconSize + ".png",2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Vanilla cream biscuit", DefaultIconPath +"vanilla_cream_biscuit_" + iconSize + ".png",2));
            mCookiesAndBiscuitsIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Vanilla ice cream", DefaultIconPath +"vanilla_ice_cream_" + iconSize + ".png",2));
            mIceCreamIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Vermicelli", DefaultIconPath +"vermicelli_" + iconSize + ".png"));
            mMiscIcons.Add(mDefaultIcons.Last());
			//mDefaultIcons.Add(new NameImage("Wafers", DefaultIconPath +"wafers_" + iconSize + ".png",2));
			mDefaultIcons.Add(new NameImage("Waffles", DefaultIconPath +"waffle_" + iconSize + ".png",3));
            mMiscIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("Walnut", DefaultIconPath +"walnut_" + iconSize + ".png",2));
            mHealthySnacksIcons.Add(mDefaultIcons.Last());
			mDefaultIcons.Add(new NameImage("White rum", DefaultIconPath +"white_rum_" + iconSize + ".png",3));
            mAlcoholIcons.Add(mDefaultIcons.Last());

			mDefaultIcons.Sort();
            mFruitsIcons.Sort();
            mVegetablesIcons.Sort();
            mHealthySnacksIcons.Sort();
            mBeveragesIcons.Sort();
            mCakesPiesIcons.Sort();
            mMeatsIcons.Sort();
            mBreadsIcons.Sort();
            mFishIcons.Sort();
            mAlcoholIcons.Sort();
            mMiscIcons.Sort();
            mSweetsIcons.Sort();
            mIceCreamIcons.Sort();
            mCookiesAndBiscuitsIcons.Sort();
            mCondimentsIcons.Sort();
            mItalianIcons.Sort();
		}

	}
}
