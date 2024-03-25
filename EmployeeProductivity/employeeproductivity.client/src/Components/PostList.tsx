import React from 'react';
import Post from "./Post";

const PostList = ({posts}) => {

    return (
        <>
            {posts.length == 0 ? null : posts.map((post) => <Post post = {post}/>)}
        </>
    );
};

export default PostList;