using System.Collections;
using Virtual;

namespace Entity {
    interface IEntity {
        void Set(VirtualEntity entity);
        IEnumerator MoveTo(VirtualEntity entity, float time);
    }
}
