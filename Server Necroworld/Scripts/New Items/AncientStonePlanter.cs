using System;

namespace Server.Items
{
	public class AncientStonePlanter : Item
	{
		[Constructable]
		public AncientStonePlanter()
			: base(0x44EF)
		{
			Movable = true;
			
			Name = "ancient stone planter";

			Weight = 1.0;
		}

		public AncientStonePlanter(Serial serial)
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