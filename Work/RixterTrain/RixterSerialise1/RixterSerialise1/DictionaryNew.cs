using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace RixterSerialise1
{
    [Serializable]
    class DictionaryNew: ISerializable, IDeserializationCallback
    {
        // Здесь закрытые поля (не показанные)
        private SerializationInfo m_siInfo; // Только для десериализации
                                            // Специальный конструктор (необходимый интерфейсу ISerializable)
                                            // для управления десериализацией
        [SecurityPermissionAttribute(
        SecurityAction.Demand, SerializationFormatter = true)]

    }
}
