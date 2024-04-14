import { title } from 'process';
import React, { useRef, useState } from 'react';
import { v4 as uuidv4 } from 'uuid';

const MyModal = ({posts, setNewPost}) => {
    const title = useRef(null)
    const date = useRef(null)
    const difficult = useRef(null)
    const description = useRef(null)

    const AddPost = () => {
        if(title.current.value != "" && date.current.value != "" && difficult.current.value != "" && difficult.current.value <= 3 && difficult.current.value > 0 && description.current.value != ""){
            const newPost = {id: Date.now(), title: title.current.value.toString(), deadLine: date.current.value.toString(), countStars: difficult.current.value.toString(), description: description.current.value.toString()}
            setNewPost([...posts, newPost])
            title.current.value = ""
            date.current.value = ""
            difficult.current.value = ""
            description.current.value = ""
        }
        else{
            window.alert('Fill all in form!')
        }
    }

    return (
        <>
        <div className="modalContent">
            <form action="" className='modalForm'>
                <input type="text" placeholder='Enter title' ref={title}/>
                <textarea name="description" cols="30" rows="10" placeholder='Enter description' ref={description}></textarea>
                <input type="number" max='3' min='1' ref={difficult} placeholder='Enter difficult'/>
                <input type="date" ref={date}/>
            </form>
            <div className="addTaskButton" onClick={() => AddPost()}>
                <button>Добавить</button>
            </div>
        </div>
        </>
    );
};

export default MyModal;