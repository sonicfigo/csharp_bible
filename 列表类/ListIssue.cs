using System.Collections;
using System.Collections.Generic;

namespace Bible.列表类
{
    /*何时使用相应的集合类
     */

    //公共接口类，使用低层次的，如icollection
    //内部自用的，private的，无要求，可使用List，较为方便。

    public class ListIssue
    {
        private IEnumerable _enumerable1; //只想枚举每个元素
        private ICollection _collection1; //需要修改，或者关注Size
        private IList _ilist1;            //需要修改，并且关注排序，或者元素的位置
        private List<string> _list1;      // 不要用？
        private ISet<string> _set1;
        private SortedSet<string> _sortedSet1; 
        private HashSet<string> _hashSet1;
    }
}
