using System.Collections.Generic;
using UnityEngine;

public static class FollowerQueue
{
    public static List<Transform> followers = new List<Transform>();

    public static void Register(Transform follower)
    {
        if (!followers.Contains(follower))
            followers.Add(follower);
    }

    public static int GetIndex(Transform follower)
    {
        return followers.IndexOf(follower);
    }

    public static Transform GetFollowTarget(Transform follower)
    {
        int index = GetIndex(follower);
        if (index == 0)
            return GameObject.FindGameObjectWithTag("Player").transform;

        return followers[index - 1];
    }
}
