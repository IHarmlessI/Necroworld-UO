using System;

namespace Server.Items
{
	[Flipable(0x1945, 0x1946)]
	public class WoodenScreen : Item
	{
		[Constructable]
		public WoodenScreen()
			: base(0x1945)
		{
			Movable = true;
			
			Name = "wooden screen";

			Weight = 10.0;
		}

		public WoodenScreen(Serial serial)
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