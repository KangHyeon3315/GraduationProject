import requests
from slack_sdk import WebClient

#alarm_man.post_message('#프로젝트','Test')
def post_message(channel, text):
    token = "xoxb-2128096878052-2122362069667-KoDqgXYpZBZYKdwOnaZqXkPL"
    response = requests.post("https://slack.com/api/chat.postMessage",
                             headers={"Authorization": "Bearer " + token},
                             data={"channel": channel, "text": text}
                             )
    print(response)

#alarm_man.direct_message('#프로젝트','홍길동','DMtest')
def direct_message(channel,userName,text):
    token = "xoxb-2128096878052-2122362069667-KoDqgXYpZBZYKdwOnaZqXkPL"
    client = WebClient(token)
    userID = 'temp'
    result_cvs = client.users_list(
        channel = channel
    )

    for index,i in enumerate(result_cvs['members']):
        if((index!=3)&(index!=5)):
            if (userName == i['real_name']):
                userID = i['id']
                break

    client.chat_postMessage(channel=userID,text=text)
