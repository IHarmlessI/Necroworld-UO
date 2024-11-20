using System;

namespace Server.Items
{
	public class OakBarrelPlanter : Item
	{
		[Constructable]
		public OakBarrelPlanter()
			: base(0x44F2)
		{
			Movable = true;
			
			Name = "oak barrel planter";

			Weight = 1.0;
		}

		public OakBarrelPlanter(Serial serial)
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