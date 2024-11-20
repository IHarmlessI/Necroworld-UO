using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class EnchantDamageTarget : Target
	{
		private EnchantDamageScroll m_Scroll;

		public EnchantDamageTarget( EnchantDamageScroll scroll ) : base( 1, false, TargetFlags.None )
		{
			m_Scroll = scroll;
		}

		protected override void OnTarget( Mobile from, object target )
		{

         if ( target is BaseMeleeWeapon )
			{
				BaseWeapon item = (BaseWeapon) target;
				
            if( item.RootParent != from )
					from.SendMessage( "You need to have it in your backpack" );
            else if( item.BlessedFor != null && item.BlessedFor != from )
					from.SendMessage( "This is not yours" );
			else if(0.3 > Utility.RandomDouble())
			{
					item.Delete();
					from.SendMessage( "Enchant failed, your have destroyed your weapon" );
					m_Scroll.Delete();
			}
				else
				{
					item.Attributes.WeaponDamage += 10;
					item.BlessedFor = from;
					from.SendMessage( "Successfully added" );
					m_Scroll.Delete();
				}
			}
			else
				from.SendMessage( "Only on weapon" );
		}
	}

	public class EnchantDamageScroll : Item
	{
		[Constructable]
		public EnchantDamageScroll() : base( 5357 )
		{
			Weight = 1.0;
			Hue = 1165;
			Name = "a Enchant Damage scroll";
		}

		public EnchantDamageScroll( Serial serial ) : base( serial )
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

		public override bool DisplayLootType{ get{ return false; } }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) // Make sure its in their pack
			{
				from.SendLocalizedMessage( 1060640 );
			}
			else
			{
				from.SendMessage( "Which weapon do you want to enchant?" );
				from.SendMessage( 33, "Only you would be able to use this weapon from now" );
				from.Target = new EnchantDamageTarget( this );
			}
		}
	}
}


