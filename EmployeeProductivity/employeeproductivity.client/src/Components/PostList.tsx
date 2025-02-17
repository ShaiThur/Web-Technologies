import React from 'react';
import Post from "./Post";

const PostList = ({posts, nameOfOption}) => {
    return (
        <>
            {posts.length == 0 ? null : posts.map((post) => <Post nameOfOption={nameOfOption} post = {post} key={post.id}/>)}
        </>
    );
};

export default PostList;