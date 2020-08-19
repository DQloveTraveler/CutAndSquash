using UnityEngine;

namespace naichilab
{
    public class TweetSample : MonoBehaviour
    {
        public void Tweet()
        {
            UnityRoomTweet.Tweet("cutandsquash", "ツイートサンプルです。");
        }

        public void TweetWithHashtag()
        {
            UnityRoomTweet.Tweet("cutandsquash", "ツイートサンプルです。", "unityroom");
        }

        public void TweetWithHashtags()
        {
            UnityRoomTweet.Tweet("cutandsquash",
                "2Dシューティング「カット&スカッシュ！」で"
                + GameManager.Instance.SquashedNum + " 匹のスライムをつぶしました！\n"
                + "プレイはこちらから→ ",
                "unityroom", "unity1week");
        }

        public void TweetWithImage()
        {
            UnityRoomTweet.TweetWithImage("cutandsquash", "ツイートサンプルです。");
        }

        public void TweetWithHashtagAndImage()
        {
            UnityRoomTweet.TweetWithImage("cutandsquash", "ツイートサンプルです。", "unityroom");
        }

        public void TweetWithHashtagsAndImage()
        {
            UnityRoomTweet.TweetWithImage("unityroom-tweet-sample", "ツイートサンプルです。", "unityroom", "unity1week");
        }
    }
}