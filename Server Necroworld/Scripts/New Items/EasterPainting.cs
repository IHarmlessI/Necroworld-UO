using System;

namespace Server.Items
{
	[Flipable(0x9CA8, 0x9CA9)]
	public class EasterPainting : Item
	{
		[Constructable]
		public EasterPainting()
			: base(0x9CA8)
		{
			Movable = true;
			
			Name = "easter painting";

			Weight = 1.0;
		}

		public EasterPainting(Serial serial)
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