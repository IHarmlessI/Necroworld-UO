using System;

namespace Server.Items
{
	[Flipable(0x194D, 0x194E)]
	public class ChineseDragonLantern : Item
	{
		[Constructable]
		public ChineseDragonLantern()
			: base(0x194D)
		{
			Movable = true;
			
			Name = "chinese dragon lantern";

			Weight = 1.0;
		}

		public ChineseDragonLantern(Serial serial)
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