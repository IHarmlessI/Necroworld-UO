using System;

namespace Server.Items
{
	[Flipable(0x9962, 0x9963)]
	public class ElephantFern : Item
	{
		[Constructable]
		public ElephantFern()
			: base(0x9962)
		{
			Movable = true;
			
			Name = "elephant fern";

			Weight = 3.0;
		}

		public ElephantFern(Serial serial)
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