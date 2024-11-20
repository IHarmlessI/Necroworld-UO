using System;

namespace Server.Items
{
	[Flipable(0x4F7B, 0x4F7E)]
	public class CupidsArrow : Item
	{
		[Constructable]
		public CupidsArrow()
			: base(0x4F7B)
		{
			Movable = true;
			
			Name = "a cupid's arrow";

			Weight = 1.0;
		}

		public CupidsArrow(Serial serial)
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