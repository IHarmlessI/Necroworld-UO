using System;

namespace Server.Items
{
	public class DragonEgg : Item
	{
		[Constructable]
		public DragonEgg(int hue)
			: base(0x47E6)
		{
			Movable = true;

			Name = "a dragon egg";
			Hue = hue;

			Weight = 1.0;
		}

		public DragonEgg(Serial serial)
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