using System;

namespace Server.Items
{
	public class Orchid : Item
	{
		[Constructable]
		public Orchid(int hue)
			: base(0x9B10)
		{
			Movable = true;
			
			Name = "orchid";

			Weight = 1.0;
			Hue = hue;
		}

		public Orchid(Serial serial)
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