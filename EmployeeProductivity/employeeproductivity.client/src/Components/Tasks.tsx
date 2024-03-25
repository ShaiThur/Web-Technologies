import React, {useRef, useState} from 'react';
import PostList from "./PostList";

const Tasks = ({posts}) => {
    const [newPosts, setNewPosts] = useState(posts)
    const title = useRef(null)
    const date = useRef(null)
    const difficult = useRef(null)

    const AddPost = () =>{
        if(title.current.value != "" && date.current.value != "" && difficult.current.value != ""){
            const newPost = {title: title.current.value.toString(), deadLine: date.current.value.toString(), countStars: difficult.current.value.toString()}
            setNewPosts([...newPosts, newPost])
            title.current.value = ""
            date.current.value = ""
            difficult.current.value = ""
        }
        else{
            window.alert('Fill all in form!')
        }
    }

    return (
        <>
            <PostList posts={newPosts}/>
        </>
    );
};

export default Tasks;