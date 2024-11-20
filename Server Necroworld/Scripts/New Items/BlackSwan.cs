using System;

namespace Server.Items
{
	[Flipable(0x9F11, 0x9F12)]
	public class BlackSwan : Item
	{
		[Constructable]
		public BlackSwan()
			: base(0x9F11)
		{
			Movable = true;
			
			Name = "a black swan";

			Weight = 1.0;
		}

		public BlackSwan(Serial serial)
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