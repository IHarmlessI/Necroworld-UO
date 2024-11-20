using System;

namespace Server.Items
{
	[Flipable(0x4D07, 0x4D08, 0x4D09)]
	public class FabergeEggs : Item
	{
		[Constructable]
		public FabergeEggs()
			: base(0x4D07)
		{
			Movable = true;
			
			Name = "a faberge egg";

			Weight = 1.0;
		}

		public FabergeEggs(Serial serial)
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