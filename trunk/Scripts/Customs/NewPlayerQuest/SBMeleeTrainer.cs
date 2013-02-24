// Created by Jamze for Mystic Online. 2/27/2010
//New Player Dungeon Quest 
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBMeleeTrainer : SBInfo
	{
		//private ArrayList m_BuyInfo = new InternalBuyInfo();
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBMeleeTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		//public override ArrayList BuyInfo { get { return m_BuyInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
                Add(new GenericBuyInfo(typeof(EnhancedBandage), 2, 200, 0xE21, 0));
                Add(new GenericBuyInfo(typeof(Arrow), 3, 500, 0xF3F, 0));
                Add(new AnimalBuyInfo(1, typeof(Horse), 250, 10, 204, 0));
                Add(new GenericBuyInfo(typeof(TrainingBow), 1000, 20, 0x13B2, 0));
                Add(new GenericBuyInfo(typeof(TrainingKatana), 1000, 20, 0x13FF, 0));
                Add(new GenericBuyInfo(typeof(TrainingKryss), 1000, 20, 0x1401, 0));
                Add(new GenericBuyInfo(typeof(Trainingclub), 1000, 20, 0x13B4, 0));					
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
