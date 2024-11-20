using System;

namespace Server.Items
{
	[Flipable(0x9960, 0x9961)]
	public class SilverTray : Item
	{
		[Constructable]
		public SilverTray()
			: base(0x9960)
		{
			Movable = true;
			
			Name = "silver tray";

			Weight = 1.0;
		}

		public SilverTray(Serial serial)
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