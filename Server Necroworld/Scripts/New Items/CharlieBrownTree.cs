using System;

namespace Server.Items
{
	[Flipable(0x4C18, 0x4C19)]
	public class CharlieBrownTree : Item
	{
		[Constructable]
		public CharlieBrownTree()
			: base(0x4C18)
		{
			Movable = true;
			
			Name = "charlie brown tree";

			Weight = 1.0;
		}

		public CharlieBrownTree(Serial serial)
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