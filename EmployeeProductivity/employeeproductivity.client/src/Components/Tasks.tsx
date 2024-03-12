import React from 'react';
import Post from "./Post";
import PostList from "./PostList";

const Tasks = ({posts}) => {
    return (
        <>
            <PostList posts={posts}/>
        </>
    );
};

export default Tasks;