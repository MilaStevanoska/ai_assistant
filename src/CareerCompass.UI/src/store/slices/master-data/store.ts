import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { initialState, MasterDataStore } from "./state";
import { AsyncAppThunk } from "../../app-thunk";
import { MasterData } from "../../../models/master-data";
import { getAreasOfInterestOptions, getCareerGoalOptions, getMasterData, getSkillsOptions, getSubjectOptions} from "../../../services/master-data";
import { IOption } from "../../../models/user";

const slice = createSlice({
  name: "masterData",
  initialState,
  reducers: {
    setMasterData: (
      state: MasterDataStore,
      { payload }: PayloadAction<MasterData>
    ) => {
      state.firstName = payload.firstName;
      state.lastName = payload.lastName;
      state.fieldOfStudy = payload.fieldOfStudy;
      state.skills = payload.skills;
      state.areasOfInterest = payload.areasOfInterest;
      state.careerGoal = payload.careerGoal;
      state.schoolYears = payload.schoolYears;
    },
    resetMasterData: (state: MasterDataStore) => {
      state.firstName = initialState.firstName;
      state.lastName = initialState.lastName;
      state.fieldOfStudy = initialState.fieldOfStudy;
      state.skills = initialState.skills;
      state.areasOfInterest = initialState.areasOfInterest;
      state.careerGoal = initialState.careerGoal;
      state.schoolYears = initialState.schoolYears;
    },
    setSkillsOptions: (
      state: MasterDataStore,
      { payload }: PayloadAction<IOption<number>[]>
    ) => {
      state.skillsOptions = payload;
    },
    setAreasOfInterestOptions: (
      state: MasterDataStore,
      { payload }: PayloadAction<IOption<number>[]>
    ) => {
      state.areasOfInterestOptions = payload;
    },
    setSubjectOptions: (
      state: MasterDataStore,
      { payload }: PayloadAction<IOption<number>[]>
    ) => {
      state.subjectOptions = payload;
    },
    setCareerGoalOptions: (
      state: MasterDataStore,
      { payload }: PayloadAction<IOption<number>[]>
    ) => {
      state.careerGoalOptions = payload;
    },
    resetSkillsOptions: (state: MasterDataStore) => {
      state.skillsOptions = initialState.skillsOptions;
    },
    resetAreasOfInterestOptions: (state: MasterDataStore) => {
      state.areasOfInterestOptions = initialState.areasOfInterestOptions;
    },
    resetSubjectOptions: (state: MasterDataStore) => {
      state.subjectOptions = initialState.subjectOptions;
    },
    resetCareerGoalOptions: (state: MasterDataStore) => {
      state.careerGoalOptions = initialState.careerGoalOptions;
    }
  },
});

export const {
  setMasterData,
  resetMasterData,
  setSkillsOptions,
  setAreasOfInterestOptions,
  setSubjectOptions,
  setCareerGoalOptions,
} = slice.actions;
export default slice;

export const init =
  (): AsyncAppThunk =>
  async (dispatch, store) => {
    try {
      const masterData = await getMasterData();
      const skillsOptions = await getSkillsOptions();
      const areasOfInterestOptions = await getAreasOfInterestOptions();
      const subjectOptions = await getSubjectOptions();
      const careerGoalOptions = await getCareerGoalOptions();

      if (
        masterData.data == null ||
        skillsOptions.data == null ||
        areasOfInterestOptions.data == null ||
        subjectOptions.data == null ||
        careerGoalOptions.data == null
      ) {
        return;
      }

      await dispatch(setMasterData(masterData.data));
      await dispatch(setSkillsOptions(skillsOptions.data));
      await dispatch(setAreasOfInterestOptions(areasOfInterestOptions.data));
      await dispatch(setSubjectOptions(subjectOptions.data));
      await dispatch(setCareerGoalOptions(careerGoalOptions.data));
    } catch { }
  };
