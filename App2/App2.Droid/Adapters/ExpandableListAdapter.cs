using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2.Droid.Adapters
{
    class ExpandableListAdapter : BaseExpandableListAdapter
    {
        private Activity context;
        private List<string> headerList; // header titles
                                              // child data in format of header title, child title
        private Dictionary<string, List<string>> childList;

        public ExpandableListAdapter(Activity context, List<string> listDataHeader, Dictionary<String, List<string>> listChildData)
        {
            this.context = context;
            this.headerList = listDataHeader;
            this.childList = listChildData;
        }
        //for cchild item view
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return childList[headerList[groupPosition]][childPosition];
        }
        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            string childText = (string)GetChild(groupPosition, childPosition);
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.SimplestRow, null);
            }
            TextView txtListChild = (TextView)convertView.FindViewById(Resource.Id.textView);
            txtListChild.Text = childText;
            return convertView;
        }
        public override int GetChildrenCount(int groupPosition)
        {
            return childList[headerList[groupPosition]].Count;
        }
        //For header view
        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return headerList[groupPosition];
        }
        public override int GroupCount
        {
            get
            {
                return headerList.Count;
            }
        }
        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }
        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string headerTitle = (string)GetGroup(groupPosition);

            convertView = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.SimplestRow, null);
            var lblListHeader = (TextView)convertView.FindViewById(Resource.Id.textView);
            lblListHeader.Text = headerTitle;

            return convertView;
        }
        public override bool HasStableIds
        {
            get
            {
                return false;
            }
        }
        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        class ViewHolderItem : Java.Lang.Object
        {
        }
    }
}