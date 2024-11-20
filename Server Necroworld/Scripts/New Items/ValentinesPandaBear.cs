using System;

namespace Server.Items
{
	[Flipable(0x48E0, 0x48E1)]
	public class ValentinesPandaBear : Item
	{
		[Constructable]
		public ValentinesPandaBear()
			: base(0x48E0)
		{
			Movable = true;
			
			Name = "valentines panda bear";

			Weight = 1.0;
		}

		public ValentinesPandaBear(Serial serial)
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