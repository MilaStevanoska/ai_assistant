import React from 'react';
import HighSchoolRecords from "../../components/highschoolRecords";
import ProfileHeader from "../../components/profileHeader";
import Skills from "../../components/skills";
import { profileData } from "../../mock_data/ProfileData";

const ProfilePage: React.FC = () => {
  return (
    <div className="bg-gray-100 min-h-screen py-10">
      <div className="container mx-auto bg-white rounded-lg shadow-md overflow-hidden">
        <h1 className="text-xl font-bold text-center pt-4 pb-2">My profile</h1>
        
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 p-6">
          <div className="md:col-span-1">
            <ProfileHeader
              name={profileData.name}
              major={profileData.major}
              profileImage={profileData.profileImage}
            />
          </div>
          
          <div className="md:col-span-2">
            <Skills skills={profileData.skills} />
            <HighSchoolRecords records={profileData.highSchoolRecords} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;