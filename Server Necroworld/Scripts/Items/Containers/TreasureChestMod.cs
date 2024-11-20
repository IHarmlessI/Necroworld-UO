// Treasure Chest Pack - Version 0.99I
// By Nerun

using Server;
using Server.Items;
using Server.Multis;
using Server.Network;
using System;

namespace Server.Items
{

// ---------- [Level 1] ----------
// Large, Medium and Small Crate
	[FlipableAttribute( 0xe3e, 0xe3f )] 
	public class TreasureLevel1 : BaseTreasureChestMod 
	{ 
		public override int DefaultGumpID{ get{ return 0x49; } }

		[Constructable] 
		public TreasureLevel1() : base( Utility.RandomList( 0xE3C, 0xE3E, 0x9a9 ) )
		{ 
			RequiredSkill = 25;
			LockLevel = this.RequiredSkill - Utility.Random( 1, 10 );
			MaxLockLevel = this.RequiredSkill;
			TrapType = TrapType.MagicTrap;
			TrapPower = 1 * Utility.Random( 1, 25 );

            DropItem( new Gold( 50, 200 ) );
			DropItem( new Gold( 50, 200 ) );
			DropItem( new Gold( 50, 200 ) );
						
			for (int i = Utility.RandomMinMax(1,2); i > 0; i--)
				if ( 0.10 > Utility.RandomDouble() ) //10% chance
				DropItem(ScrollOfTranscendence.CreateRandom(1, 5));
			
			if ( 0.05 > Utility.RandomDouble() ) //5% chance 
				DropItem( new TreasureMap(Utility.RandomMinMax(1, 3), Map.Felucca) );
			
			if ( 0.2 > Utility.RandomDouble() ) //20% chance 
				DropItem( Loot.RandomStatue() );
			
				// Magical ArmorOrWeapon
			for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
			{
				Item item = Loot.RandomArmorOrShieldOrWeapon();

                if (!Core.AOS)
                {
                    if (item is BaseWeapon)
                    {
                        BaseWeapon weapon = (BaseWeapon)item;
                        weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(4);
                        weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(4);
                        weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(4);
                        weapon.Quality = ItemQuality.Normal;
                    }
                    else if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;
                        armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(4);
                        armor.Durability = (ArmorDurabilityLevel)Utility.Random(4);
                        armor.Quality = ItemQuality.Normal;
                    }
                }
                else
                    AddLoot(item);
			}
	}

		public TreasureLevel1( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt();
		} 
	}

// ---------- [Level 1 Hybrid] ----------
// Large, Medium and Small Crate
	[FlipableAttribute( 0xe3e, 0xe3f )] 
	public class TreasureLevel1h : BaseTreasureChestMod 
	{ 
		public override int DefaultGumpID{ get{ return 0x49; } }

		[Constructable] 
		public TreasureLevel1h() : base( Utility.RandomList( 0xE3C, 0xE3E, 0x9a9 ) ) 
		{ 
			RequiredSkill = 35;
			LockLevel = this.RequiredSkill - Utility.Random( 1, 10 );
			MaxLockLevel = this.RequiredSkill;
			TrapType = TrapType.MagicTrap;
			TrapPower = 1 * Utility.Random( 1, 25 );

			DropItem( new Gold( 100, 400 ) );
			DropItem( new Gold( 100, 400 ) );
			DropItem( new Gold( 100, 400 ) );
						
			for (int i = Utility.RandomMinMax(1,2) + 1; i > 0; i--)
				if ( 0.15 > Utility.RandomDouble() ) //15% chance
				DropItem(ScrollOfTranscendence.CreateRandom(1, 5));
			
			if ( 0.10 > Utility.RandomDouble() ) //10% chance 
				DropItem( new TreasureMap(Utility.RandomMinMax(1, 3), Map.Felucca) );
			
			if ( 0.50 > Utility.RandomDouble() ) //50% chance 
				DropItem( Loot.RandomStatue() );
			
			for (int i = Utility.RandomMinMax(1,2); i > 0; i--)
				DropItem( Loot.RandomRareGem() );

				// Magical ArmorOrWeapon
			for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
			{
				Item item = Loot.RandomArmorOrShieldOrWeapon();

                if (!Core.AOS)
                {
                    if (item is BaseWeapon)
                    {
                        BaseWeapon weapon = (BaseWeapon)item;
                        weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(4);
                        weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(4);
                        weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(4);
                        weapon.Quality = ItemQuality.Normal;
                    }
                    else if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;
                        armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(4);
                        armor.Durability = (ArmorDurabilityLevel)Utility.Random(4);
                        armor.Quality = ItemQuality.Normal;
                    }
                }
                else
                    AddLoot(item);
			}
		} 

		public TreasureLevel1h( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	}

// ---------- [Level 2] ----------
// Large, Medium and Small Crate
// Wooden, Metal and Metal Golden Chest
// Keg and Barrel
	[FlipableAttribute( 0xe43, 0xe42 )] 
	public class TreasureLevel2 : BaseTreasureChestMod 
	{
		[Constructable] 
		public TreasureLevel2() : base( Utility.RandomList( 0xe3c, 0xE3E, 0x9a9, 0xe42, 0x9ab, 0xe40, 0xe7f, 0xe77 ) ) 
		{ 
			RequiredSkill = 52;
			LockLevel = this.RequiredSkill - Utility.Random( 1, 10 );
			MaxLockLevel = this.RequiredSkill;
			TrapType = TrapType.MagicTrap;
			TrapPower = 2 * Utility.Random( 1, 25 );

			DropItem( new Gold( 200, 900 ) );
			DropItem( new Gold( 200, 900 ) );
			DropItem( new Gold( 200, 900 ) );
			
			for (int i = Utility.RandomMinMax(1,2); i > 0; i--)
				if ( 0.15 > Utility.RandomDouble() ) //15% chance
					DropItem( new ScrollOfAlacrity(PowerScroll.Skills[Utility.Random(PowerScroll.Skills.Count)]) );
					
			for (int i = Utility.RandomMinMax(1,3) + 1; i > 0; i--)
				if ( 0.15 > Utility.RandomDouble() ) //15% chance
				DropItem(ScrollOfTranscendence.CreateRandom(1, 5));
			
			if ( 0.10 > Utility.RandomDouble() ) //10% chance 
				DropItem( new TreasureMap(Utility.RandomMinMax(2, 4), Map.Felucca) );
			
			if ( 0.50 > Utility.RandomDouble() ) //50% chance 
				DropItem( Loot.RandomStatue() );
			
			for (int i = Utility.RandomMinMax(1,4) + 1; i > 0; i--)
				DropItem( Loot.RandomRareGem() );

				// Magical ArmorOrWeapon
			for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
			{
				Item item = Loot.RandomArmorOrShieldOrWeapon();

                if (!Core.AOS)
                {
                    if (item is BaseWeapon)
                    {
                        BaseWeapon weapon = (BaseWeapon)item;
                        weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(4);
                        weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(4);
                        weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(4);
                        weapon.Quality = ItemQuality.Normal;
                    }
                    else if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;
                        armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(4);
                        armor.Durability = (ArmorDurabilityLevel)Utility.Random(4);
                        armor.Quality = ItemQuality.Normal;
                    }
                }
                else
                    AddLoot(item);
			}
			
			for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
                AddLoot(Loot.RandomJewelry());
		} 

		public TreasureLevel2( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 

// ---------- [Level 3] ----------
// Wooden, Metal and Metal Golden Chest
	[FlipableAttribute( 0x9ab, 0xe7c )] 
	public class TreasureLevel3 : BaseTreasureChestMod 
	{ 
		public override int DefaultGumpID{ get{ return 0x4A; } }

		[Constructable] 
		public TreasureLevel3() : base( Utility.RandomList( 0x9ab, 0xe40, 0xe42 ) ) 
		{ 
			RequiredSkill = 71;
			LockLevel = this.RequiredSkill - Utility.Random( 1, 10 );
			MaxLockLevel = this.RequiredSkill;
			TrapType = TrapType.MagicTrap;
			TrapPower = 3 * Utility.Random( 1, 25 );

			DropItem( new Gold( 300, 1200 ) );
			DropItem( new Gold( 300, 1200 ) );
			DropItem( new Gold( 300, 1200 ) );
			DropItem( Loot.RandomTalisman() );
			
			for (int i = Utility.RandomMinMax(1,3) + 1; i > 0; i--)
				if ( 0.35 > Utility.RandomDouble() ) //35% chance
					DropItem( new ScrollOfAlacrity(PowerScroll.Skills[Utility.Random(PowerScroll.Skills.Count)]) );
					
			for (int i = Utility.RandomMinMax(1,3) + 1; i > 0; i--)
				if ( 0.35 > Utility.RandomDouble() ) //35% chance
				DropItem(ScrollOfTranscendence.CreateRandom(1, 5));
			
			if ( 0.10 > Utility.RandomDouble() ) //10% chance 
				DropItem( new TreasureMap(Utility.RandomMinMax(3, 5), Map.Felucca) );
			
			if ( 0.50 > Utility.RandomDouble() ) //50% chance 
				DropItem( Loot.RandomStatue() );
			
			for (int i = Utility.RandomMinMax(2,5) + 1; i > 0; i--)
				DropItem( Loot.RandomRareGem() );

			// Magical ArmorOrWeapon
			for( int i = Utility.Random( 1, 3 ) + 1; i > 1; i-- )
			{
				Item item = Loot.RandomArmorOrShieldOrWeapon();

                if (!Core.AOS)
                {
                    if (item is BaseWeapon)
                    {
                        BaseWeapon weapon = (BaseWeapon)item;
                        weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(4);
                        weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(4);
                        weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(4);
                        weapon.Quality = ItemQuality.Normal;
                    }
                    else if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;
                        armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(4);
                        armor.Durability = (ArmorDurabilityLevel)Utility.Random(4);
                        armor.Quality = ItemQuality.Normal;
                    }
                }
                else
                    AddLoot(item);
			}
			
			for( int i = Utility.Random( 1, 2 ); i > 1; i-- )
                AddLoot(Loot.RandomJewelry());

			// Magic clothing (not implemented)
			
			// Magic jewelry (not implemented)
		} 

		public TreasureLevel3( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 

// ---------- [Level 4] ----------
// Wooden, Metal and Metal Golden Chest
	[FlipableAttribute( 0xe41, 0xe40 )] 
	public class TreasureLevel4 : BaseTreasureChestMod 
	{ 
		[Constructable] 
		public TreasureLevel4() : base( Utility.RandomList( 0xe40, 0xe42, 0x9ab ) )
		{ 
			RequiredSkill = 82;
			LockLevel = this.RequiredSkill - Utility.Random( 1, 10 );
			MaxLockLevel = this.RequiredSkill;
			TrapType = TrapType.MagicTrap;
			TrapPower = 4 * Utility.Random( 1, 25 );

			DropItem( new Gold( 400, 1500 ) );
			DropItem( new Gold( 400, 1500 ) );
			DropItem( new Gold( 400, 1500 ) );
			DropItem( Loot.RandomTalisman() );
			
			for (int i = Utility.RandomMinMax(1,3) + 1; i > 0; i--)
				if ( 0.50 > Utility.RandomDouble() ) //50% chance
					DropItem( new ScrollOfAlacrity(PowerScroll.Skills[Utility.Random(PowerScroll.Skills.Count)]) );

			for (int i = Utility.RandomMinMax(1,3) + 1; i > 0; i--)
				if ( 0.50 > Utility.RandomDouble() ) //50% chance
				DropItem(ScrollOfTranscendence.CreateRandom(1, 5));
			
			if ( 0.20 > Utility.RandomDouble() ) //20% chance 
				DropItem( new TreasureMap(Utility.RandomMinMax(5, 7), Map.Felucca) );
			
			if ( 0.50 > Utility.RandomDouble() ) //50% chance 
				DropItem( Loot.RandomStatue() );
			
			for (int i = Utility.RandomMinMax(3,6) + 1; i > 0; i--)
				DropItem( Loot.RandomRareGem() );

			// Magical ArmorOrWeapon
			for( int i = Utility.Random( 1, 6 ) + 2; i > 1; i-- )
			{
				Item item = Loot.RandomArmorOrShieldOrWeapon();

                if (!Core.AOS)
                {
                    if (item is BaseWeapon)
                    {
                        BaseWeapon weapon = (BaseWeapon)item;
                        weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(4);
                        weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(4);
                        weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(4);
                        weapon.Quality = ItemQuality.Normal;
                    }
                    else if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;
                        armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(4);
                        armor.Durability = (ArmorDurabilityLevel)Utility.Random(4);
                        armor.Quality = ItemQuality.Normal;
                    }
                }
                else
                    AddLoot(item);
			}
			
			for( int i = Utility.Random( 1, 3 ) + 1; i > 1; i-- )
				AddLoot( Loot.RandomJewelry() );
		} 

		public TreasureLevel4( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 

}
