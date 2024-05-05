import axios from 'axios';
import { title } from 'process';
import React, { useRef, useState } from 'react';
import { v4 as uuidv4 } from 'uuid';
import { IPost } from '../Entites/Post.interface';
import { useNavigate } from 'react-router-dom';

const MyModal = ({posts, setNewPost}) => {
    const title = useRef(null)
    const date = useRef(null)
    const difficult = useRef(null)
    const description = useRef(null)
    const navigate = useNavigate();
    const [newPost] = useState<IPost>({
        title: "",
        mainInfo: "",
        deadline: new Date(),
        complexity: 0
    })

    const RefreshToken = async() =>{
        const email = sessionStorage.getItem('userEmail')
        const response = await axios.request({
            method: 'post',
            url: '/api/User/RefreshUserToken',
            withCredentials: true,
            headers: {
                login: email,
            }
        })
        localStorage.setItem('accessToken', response.data.accessToken)
    }

    const AddPost = () => {
        if(title.current.value != "" && date.current.value != "" && difficult.current.value != "" && difficult.current.value <= 3 && difficult.current.value > 0 && description.current.value != ""){
            newPost.title = title.current.value.toString();
            newPost.complexity = Number(difficult.current.value);
            newPost.deadline = new Date(date.current.value);
            newPost.mainInfo = description.current.value.toString();
            newPost.userLogin = sessionStorage.getItem('userEmail')
            console.log(newPost)
            AddPost_PostRequest().then((status) =>{
                const newPostInList = {title: newPost.title.toString(), deadLine: newPost.deadline.toString(), countStars: newPost.complexity.toString()}
                setNewPost([...posts, newPostInList])
                console.log(status);
            }).catch((error) => {
                if (error.response.status === 401) {
                    RefreshToken().then(() => {
                        AddPost_PostRequest().then((status) => {
                            const newPostInList = {title: newPost.title.toString(), deadLine: newPost.deadline.toString(), countStars: newPost.complexity.toString()}
                            setNewPost([...posts, newPostInList])
                            console.log(status);
                        }).catch(() => {
                            console.log('kal')
                        });
                    }).catch(() => {
                        alert('Cant refresh token');
                    });
                } else {
                    alert('Cant do new post');
                }
            });
            title.current.value = "";
            date.current.value = "";
            difficult.current.value = "";
            description.current.value = "";
        }
        else{
            window.alert('Fill all in form!')
        }
    }

    const AddPost_PostRequest = async() =>{
        const accessToken = localStorage.getItem('accessToken');
        const response = await axios.request({
            url: "api/Job/CreateJob",
            method: 'post',
            data: {
                userName: newPost.userLogin,
                title: newPost.title,
                mainInfo: newPost.mainInfo,
                complexity: newPost.complexity-1,
                deadline: newPost.deadline
            },
            headers: {
                Authorization: `Bearer ${accessToken}`,
            }
        });
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
                <button>Add</button>
            </div>
        </div>
        </>
    );
};

export default MyModal;