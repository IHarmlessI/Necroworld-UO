using System;

namespace Server.Items
{
	public class GrecianPlanter : Item
	{
		[Constructable]
		public GrecianPlanter()
			: base(0x44F0)
		{
			Movable = true;
			
			Name = "grecian planter";

			Weight = 1.0;
		}

		public GrecianPlanter(Serial serial)
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