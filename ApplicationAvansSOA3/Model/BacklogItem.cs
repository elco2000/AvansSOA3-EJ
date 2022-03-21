﻿using System.Collections;

namespace ApplicationAvansSOA3
{
    public class BacklogItem
    {
        private string title;
        private string description;
        private bool isDone;
        private IList activities;
        
        public BacklogItem(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.isDone = false;
            this.activities = new List<Activity>();
        }

        public string GetTitle() 
        {
            return title; 
        }

        public void CreateActivity(string title, string description)
        {
            activities.Add(new Activity(title, description));
        }

        public IList GetActivities()
        {
            return activities;
        }

        public void SetActivities(IList activities)
        {
            this.activities = activities;
        }

        public void CloseBacklogItem()
        {
            bool allActivitiesClosed = true;
            foreach (Activity activity in activities)
            {
                if (!activity.GetIsDone())
                {
                    allActivitiesClosed = false;
                    break;
                }
            }

            if (allActivitiesClosed) { SetIsDone(true); }
        }

        public bool GetIsDone()
        {
            return this.isDone;
        }

        public void SetIsDone(bool isDone)
        {
            this.isDone = isDone;
        }
    }
}