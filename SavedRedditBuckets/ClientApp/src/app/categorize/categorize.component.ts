import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-categorize-component',
  templateUrl: './categorize.component.html'
})
export class CategorizeComponent
{
  public savedItems: RedditRequestChildObject[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {

    http.get<RedditRequestChildObject[]>(baseUrl + 'redditsavedpost').subscribe(result => {
      this.savedItems = result;
    }, error => console.error(error));

  }
}

interface RedditSavedItem
{
  subreddit: string;
  permaLink: string;
  created_utc: string;
  title: string;
  body: string;
  link_Title: string;
}

interface RedditRequestChildObject
{
  kind: string;
  data: RedditSavedItem;
}
