using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a citrine dragon corpse" )]
	public class CitrineDragon : BaseCreature
	{
		[Constructable]
		public CitrineDragon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a citrine dragon";
			Body = 106;
			Hue = 1281;
			BaseSoundID = 362;

			SetStr( 800, 900 );
			SetDex( 68, 200 );
			SetInt( 488, 620 );

			SetHits( 500, 550 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 50, 55 );
			SetResistance( ResistanceType.Cold, 45, 55 );
			SetResistance( ResistanceType.Poison, 50, 55 );
			SetResistance( ResistanceType.Energy, 50, 55 );

			SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.Magery, 80.1, 100.0 );
			SetSkill( SkillName.Meditation, 52.5, 75.0 );
			SetSkill( SkillName.MagicResist, 100.3, 130.0 );
			SetSkill( SkillName.Tactics, 97.6, 110.0 );
			SetSkill( SkillName.Wrestling, 97.6, 110.0 );

			Fame = 22500;
			Karma = -22500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 95.0;

			VirtualArmor = 70;

			SetSpecialAbility(SpecialAbility.DragonBreath);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.Gems, 25 );
		}

		public override int GetIdleSound()
		{
			return 0x2D5;
		}

		public override int GetHurtSound()
		{
			return 0x2D1;
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override int Scales{ get{ return 10; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Yellow; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override bool CanFly { get { return true; } }

		public CitrineDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}