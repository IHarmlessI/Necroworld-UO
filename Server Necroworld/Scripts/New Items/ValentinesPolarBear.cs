using System;

namespace Server.Items
{
	[Flipable(0x48E2, 0x48E3)]
	public class ValentinesPolarBear : Item
	{
		[Constructable]
		public ValentinesPolarBear()
			: base(0x48E2)
		{
			Movable = true;
			
			Name = "valentines polar bear";

			Weight = 1.0;
		}

		public ValentinesPolarBear(Serial serial)
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