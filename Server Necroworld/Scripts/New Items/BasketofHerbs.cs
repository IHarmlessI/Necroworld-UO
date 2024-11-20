using System;

namespace Server.Items
{
	public class BasketofHerbs : Item
	{
		[Constructable]
		public BasketofHerbs()
			: base(0x194F)
		{
			Movable = true;
			
			Name = "basket of herbs";

			Weight = 1.0;
		}

		public BasketofHerbs(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}