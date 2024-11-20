using System;

namespace Server.Items
{
	public class GargoyleWingsStatue : Item
	{
		[Constructable]
		public GargoyleWingsStatue()
			: base(0x42C5)
		{
			Movable = true;
			
			Name = "gargoyle wings statue";

			Weight = 5.0;
		}

		public GargoyleWingsStatue(Serial serial)
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