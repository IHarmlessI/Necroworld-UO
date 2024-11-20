using System;

namespace Server.Items
{
	[Flipable(0x9969, 0x996A)]
	public class JapaneseMapleTree : Item
	{
		[Constructable]
		public JapaneseMapleTree(int hue)
			: base(0x9969)
		{
			Movable = true;
			
			Name = "japanese maple tree";
			Hue = 1540;

			Weight = 1.0;
		}

		public JapaneseMapleTree(Serial serial)
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